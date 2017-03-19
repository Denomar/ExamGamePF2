using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

    int score = 10;
	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.SetInt("Level2", 1);
        PlayerPrefs.SetInt("Level", score);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Time()
    {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(4);   
    }
}
