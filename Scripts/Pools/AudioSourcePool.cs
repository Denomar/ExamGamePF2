using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioSourcePool : MonoBehaviour
{
    private static AudioSourcePool _instance;

    [SerializeField] private AudioSource _prefab;
    [SerializeField] private int _sourcePoolSize = 10;

    private List<AudioSource> _sources;
    private List<AudioSource> _activeSources;
    private List<AudioSource> _freeSources;

	// Use this for initialization
	void Awake ()
	{
	    _instance = this;
	    InitSources();
	}

    private void InitSources()
    {
        _sources = new List<AudioSource>(_sourcePoolSize);
        _freeSources = new List<AudioSource>(_sourcePoolSize);
        _activeSources = new List<AudioSource>(_sourcePoolSize);

        for (int i = 0; i < _sourcePoolSize; i++)
        {
            GameObject obj = Instantiate(_prefab.gameObject, transform) as GameObject;
            ConfigAfterReturned(obj);
            AudioSource source = obj.GetComponent<AudioSource>();
            _sources.Add(source);
            _freeSources.Add(source);
        }
    }

    public void DestroyAudioSource(AudioSource source)
    {
        if (_activeSources.Remove(source))
        {
            _freeSources.Add(source);
            ConfigAfterReturned(source.gameObject);
        }
    }

    public AudioSource GetAudioSource()
    {
        AudioSource source = _freeSources[0];
        _freeSources.RemoveAt(0);
        _activeSources.Add(source);
        ConfigBeforeGet(source.gameObject);
        return source;
    }

    private void ConfigAfterReturned(GameObject source)
    {
        source.SetActive(false);
        source.transform.parent = transform;
        source.transform.localPosition = Vector3.zero;
    }

    private void ConfigBeforeGet(GameObject source)
    {
        source.SetActive(true);
    }

    public void Execute()
    {
        List<AudioSource> sources = new List<AudioSource>();
        foreach (var activeSource in _activeSources)
        {
            if (!activeSource.isPlaying)
            {
                sources.Add(activeSource);
            }
        }
        foreach (var source in sources)
        {
            DestroyAudioSource(source);
        }
    }

    public void SetVolume(float vol)
    {
        foreach (var source in _sources)
        {
            source.volume = vol;
        }
    }

    public static AudioSourcePool GetInstance()
    {
        return _instance;
    }
	

}
