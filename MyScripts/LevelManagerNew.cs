using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManagerNew : MonoBehaviour {

    [Serializable]
    public class Level
    {
        public string levelText;
        public int unlocked;
        public bool isInteractable;

        public Button.ButtonClickedEvent onClickEvent;

    }
    public List<Level> levelList;
    public Transform Spacer;    
    public GameObject levelButton;
	// Use this for initialization
	void Start ()
    {
      //  DeleteAll();
        FillList();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void FillList()
    {
        foreach(var level in levelList )
        {
            GameObject newButton = Instantiate(levelButton) as GameObject;
            LevelButtonNew button = newButton.GetComponent<LevelButtonNew>();
            button.levelText.text = level.levelText;


           


           if (PlayerPrefs.GetInt("Level" + button.levelText.text + "_score") == 1)
            {
                level.unlocked = 1;
                level.isInteractable = true;

            }
            button.unlocked = level.unlocked;
            button.GetComponent<Button>().interactable = level.isInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => loadLevels("Level" + button.levelText.text));

            if(PlayerPrefs.GetInt("Level" + button.levelText.text + "_score") > 0)
            {
                button.Star1.SetActive(true);

            }
            if (PlayerPrefs.GetInt("Level" + button.levelText.text + "_score") >= 5000)
            {
                button.Star2.SetActive(true);

            }
            if (PlayerPrefs.GetInt("Level" + button.levelText.text + "_score") >= 9999)
            {
                button.Star3    .SetActive(true);

            }

            newButton.transform.SetParent(Spacer);
        }
        SaveAll();
    }

    void SaveAll()
    {
        if(PlayerPrefs.HasKey("Level1"))
        {
            return;

        }
        else { 
        GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        foreach(GameObject buttons in allButtons)
        {
            LevelButtonNew button = buttons.GetComponent<LevelButtonNew>();
            PlayerPrefs.SetInt("Level" + button.levelText.text, button.unlocked);

         }
      }
   }

    void DeleteAll()
    {

        PlayerPrefs.DeleteAll();

    }
    void loadLevels(string value)
    {
        //Application.LoadLevel(value);
        SceneManager.LoadScene(value);

    }
}
