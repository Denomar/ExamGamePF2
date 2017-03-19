using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {


    public GameObject objItem;
    public Texture2D Icon;
    public string sname;
    public enType Type = enType.Armor;
    public int Damage;
    public int Protection;
    public int Regen;
    public int Agility; //Ловкость
    


    public enum enType
    {
        Weapon,
        Armor,
        Food,
        Amulet

    }


    public bool info = false;
    private GameObject Player;
    private MainInv mi; //ссылка на скрипт для записи
    private bool state = false;
    private GameObject ItemObject;



	// Use this for initialization
	void Start () {
        gameObject.name = gameObject.name.Replace("(Clone)", "");
        Player = GameObject.Find("Player");
        mi = Player.GetComponent<MainInv>();
        ItemObject = Resources.Load(gameObject.name) as GameObject;
	}
	
    void OnMouseOver()
    {

        info = true;

    }


    void OnMouseExit()
    {

        info = false;
    }


    void OnGui()
    {
        if (info == true)
        {
  
            GUI.Label(new Rect(Input.mousePosition.x + 15, Screen.height - Input.mousePosition.y, 200, 80), "Name: " + sname);
            GUI.Label(new Rect(Input.mousePosition.x + 15, Screen.height - Input.mousePosition.y,  200, 80), "Type: " + Type.ToString());
         //   switch(Type)
         //   {
         //       case enType.Armor:
         //           GUI.Label(new Rect(Input.mousePosition.x + 15, Screen.height - Input.mousePosition.y, +30, 200, 80), "Protection: " + Protection);
         //           break;


         //       case enType.Weapon:
         //           GUI.Label(new Rect(Input.mousePosition.x + 15, Screen.height - Input.mousePosition.y, 30, 200, 80), "Damage: " + Damage);
         //           break;

         //       case enType.Food:
         //           GUI.Label(new Rect(Input.mousePosition.x + 15, Screen.height - Input.mousePosition.y, 30, 200, 80), "Regeneratinn: " + Regen);
         //           break;

         //       case enType.Amulet:
         //           GUI.Label(new Rect(Input.mousePosition.x + 15, Screen.height - Input.mousePosition.y, 30, 200, 80), "Agility++: " + Agility);
         //           break;

         //}

       }
    }
           void OnMouseDown() {

        for(int i = 0; i < 14; i++)
        {
            if(mi.allItems[i] == null && (state == false))
        {

            mi.allItems[i] = ItemObject;
            //state == true;
        }

        }
        if (state)
        {
            Destroy(gameObject);


        }
        else
        {
            Debug.Log("MaxInv");
        }

    }









    



   
	// Update is called once per frame
	void Update () {
	
	}
}
