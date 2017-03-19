using UnityEngine;
using System.Collections;

public  class PrefsLoaderScript : MonoBehaviour
{
    private string  _heroName;

    // Use this for initialization
	void Start ()
	{
	    GameObject theHero = GameObject.Find("hero");
	    _heroName= PlayerPrefs.GetString("hero");
	}


    	void Update ()
             {
                 Debug.Log("Place for hero name");

             }

	    //UsernameSaver usernameSaver = theHero.GetComponent<UsernameSaver>();
	  //  _heroName = usernameSaver.MyGameData.GetInstance().GetName("L2");

	}

	// Update is called once per frame



