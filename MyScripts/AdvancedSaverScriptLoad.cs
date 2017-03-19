using UnityEngine;
using System.Collections;

public class AdvancedSaverScriptLoad : MonoBehaviour
{

    public int intNum;
    public float floatNum;

    public string Name;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.K))
	    {
	        if (PlayerPrefs.HasKey("NumInt"))
	        {
	            intNum = PlayerPrefs.GetInt("NumInt");

	            }
	            else intNum = 0;

	        if (PlayerPrefs.HasKey("NumFloat"))
	        {
	          floatNum = PlayerPrefs.GetFloat("NumFloat");

	        }
	        else intNum = 0;

	        if (PlayerPrefs.HasKey("Name"))
	        {
	           Name = PlayerPrefs.GetString("Name");

	        }
	        else Name = "";
	        Debug.Log("Items load");
	        }
	    if (Input.GetKeyDown(KeyCode.L))
	    {
             PlayerPrefs.DeleteKey("Name");
	         PlayerPrefs.DeleteAll();
	         PlayerPrefs.Save();
	        Debug.Log("Items deleted");

	    }

	    }

	
	}

