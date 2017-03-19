
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControlsScript : MonoBehaviour {

	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	//void Update () {
	
	//}
  public   void newgame()
    {
        Application.LoadLevel("L1");
        Debug.Log("L1");

    }
   public  void exit()
    {
        Application.Quit();
        Debug.Log("Exit");

    }

    public void toLevel2Method()
    {
        SceneManager.LoadScene("L2");

    }

    public void toInstanceArea()
    {
        SceneManager.LoadScene("Instance");
    }

    public void toMainMenumethod()
    {
        SceneManager.LoadScene("MenuScene");

    }
}
