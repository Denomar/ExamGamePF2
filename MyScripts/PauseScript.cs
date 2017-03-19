using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour
{

	public GameObject menu1;// = new Texture2D(10, 10);
   // public menu;
    bool paused = false;
  //  public Camera camera = new Camera();
    //public AudioClip music = new GameObject();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
            if (!paused)
            {

                
                Time.timeScale = 0;
                paused = true;
                //  camera.GetComponent(SepiaToneEffect).enabled = true;
                // music.audio.Pause;
               // guiTexture.texture = picture;
                menu1.SetActive(true);
               //menu.
                
                
                
            }
            else
            {


                Time.timeScale = 1;
                paused = false;

                // camera.GetComponent(SepiaToneEffect).enabled = false;
                //  music.audio.Play();
               menu1.SetActive(false);
              }
            }
    }
