using UnityEngine;
using System.Collections.Generic;
using System.Linq.Expressions;
using Random = System.Random;

namespace gameservices
{
    public class AudioService : Service, IOnAudioPreferenceChanged
    {
        public const string MenuTheme = "MenuTheme";
        public const string SoundTrack1 = "SoundTrack1";
        public const string SoundTrack2 = "SoundTrack2";

        private static AudioService _instance;
        [SerializeField] private List<AudioClip> _clips;
        [SerializeField] private AudioClip _menuTheme;
        [SerializeField] private AudioClip _soundTrack1;
        [SerializeField] private AudioClip _soundTrack2;
        [SerializeField] private AudioSource _musicSource;


        private bool _globalSoundsState = true;

        private Dictionary<string, AudioSource> _lib;

        // Use this for initialization
        void Awake()
        {
            _instance = this;
            _lib = new Dictionary<string, AudioSource>();
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            ConfigurationService.GetInstance().AddAudioListener(this);
        }

        public void PlaySound(bool state, string name, bool loop, AudioClip clip, Vector3 pos)
        {
            if (_globalSoundsState)
            {
                if (state)
                {
                    AudioSource source;
                    if (_lib.ContainsKey(name))
                    {
                        source = _lib[name];
                        if (!source.gameObject.active)
                        {
                            _lib.Remove(name);
                            PlaySound(state, name, loop, clip, pos);
                            return;
                        }
                    }
                    else
                    {
                        source = AudioSourcePool.GetInstance().GetAudioSource();
                        source.transform.position = pos;
                        _lib.Add(name, source);
                    }
                    source.clip = clip;
                    source.loop = loop;
                    source.Play(0);
                }
                else
                {
                    if (_lib.ContainsKey(name))
                    {
                        AudioSource source = _lib[name];
                        source.Stop();
                        AudioSourcePool.GetInstance().DestroyAudioSource(source);
                        _lib.Remove(name);
                    }
                }
            }
        }

        public void PlaySound(bool state, string name, bool loop, AudioClip clip)
        {
            PlaySound(state, name, loop, clip, Vector3.zero);
        }

        public void PlayMenuTheme()
        {
            PlayMusic(true, _menuTheme);
        }

        public void PlayMusic(bool loop, AudioClip clip)
        {
            _musicSource.clip = clip;
            _musicSource.loop = loop;
            _musicSource.Play();
        }

        public void PlaySoundtrack(int index)
        {
            switch (index)
            {
                case 0:
                    PlayMusic(true, _soundTrack1);
                    break;

                case 1:
                    PlayMusic(true, _soundTrack2);
                    break;

                default:
                    PlayMenuTheme();
                    break;
            }
        }

        public void PlaySoundtrack()
        {
            Random random = new Random();
            PlaySoundtrack(random.Next(0, 1));
        }

        public override void Execute()
        {
            AudioSourcePool.GetInstance().Execute();
        }


        public static AudioService GetInstance()
        {
            return _instance;
        }

        public void OnSoundStatusChanged(bool state)
        {
            _globalSoundsState = state;
        }

        public void OnMusicStatusChanged(bool state)
        {
            _musicSource.gameObject.SetActive(state);
        }

        public void OnSoundVolumeChanged(float value)
        {
            AudioSourcePool.GetInstance().SetVolume(value);
        }

        public void OnMusicVolumeChanged(float value)
        {
            _musicSource.volume = value;
        }
    }
}
