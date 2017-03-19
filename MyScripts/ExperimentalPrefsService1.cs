 using UnityEngine;
using System.Collections;

public class ExperimentalPrefsService1 : MonoBehaviour
{
    private string key = "MyFirstKey";

    public int value;

    public string name;
	// Use this for initialization
	void Start ()
	{
	    PlayerPrefs.SetInt(key,42);
	    PlayerPrefs.SetString(name,"AM");
	    Debug.Log(PlayerPrefs.GetInt(key).ToString());
	    Debug.Log(PlayerPrefs.GetString(name).ToString());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
