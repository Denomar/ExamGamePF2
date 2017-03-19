using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuSelectionScript : MonoBehaviour {

 public   void startNewGame()
    {
        SceneManager.LoadScene("EnterHeroNameScene");
    }

  public   void levelSelection()
    {
        SceneManager.LoadScene("SceneManagerLevel");

    }

    public void aboutUsScene()
    {

        SceneManager.LoadScene("AboutUsScene");
    }

    public void gameExit()
    {
        Application.Quit();

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
