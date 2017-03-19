using UnityEngine;
using System.Collections;

public  class Service : MonoBehaviour {

    int levels;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void Awake()
    {
        DontDestroyOnLoad(this);


    }
}
