using UnityEngine;
using System.Collections;

public class AdvancedSaverScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	    PlayerPrefs.SetInt("NumInt",52);
	    PlayerPrefs.SetFloat("NumFloat", 1.3f);
	    PlayerPrefs.SetString("Name","Tutorial");

	    PlayerPrefs.Save();
	    Debug.Log("Items Saved");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
