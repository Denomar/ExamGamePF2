using UnityEngine;
using System.Collections;

public class MainInv : MonoBehaviour {


    private GameObject goA; //Броня
    private GameObject goS; //Меч

    public bool state15; //Надето оружие?
    public bool state17; //Надета броня?
    public bool state18; //Надет амулет?

    public GameObject[] allItems = new GameObject[41]; // хранит элементы инвентаря
    public GameObject cm; //Ссылка на камеру

    void Start()
    {

    }



 //   void Update()
   // {
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {

    //        if (Global.visable)
    //        {

    //            Global.visable == false;
    //        }
    //        else
    //        {
    //            Global.visable == true;

    //        }
       // }


        //Ячейка оружия
       // if (allItems[15] != null && (!state15))
        //{
        //    goS = Instantiate(allItems[15].GetComponent<Item>().objItem as GameObject;
        //    goS.transform.parent = GameObject.Find("Sword").transform;
        //    goS.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //    goS.transform.localPosition = new Vector3(0, 0, 0);
        //    gameObject.GetComponent<Skills>().dam += allItems[15].GetComponent<Item>().Damage;
        //    state15 = true;

        //}

        //if (allItems[15] == null) && (!state15))
        //        {

        //    gameObject.GetComponent<Skills>.dam = 0;
        //    state15 = false;

        //}

        ////Ячейка брони

        //if (allItems[16] != null && (!state15))
        //{
        //    goS = Instantiate(allItems[15].GetComponent<Item>().objItem) as GameObject;
        //    goS.transform.parent = GameObject.Find("Sword").transform;
        //    goS.transform.localRotation = Quaternion.Euler(0, 0, 0);

        //    goS.transform.localPosition = new Vector3(0, 0, 0);
        //    gameObject.GetComponent<Skills>().dam += allItems[16].GetComponent<Item>().Protection;
        //    state15 = true;

        //}

        //if (allItems[16] == null) && (!state15)
        //        {

        //    gameObject.GetComponent<Skills>.dam = 0;
        //    state15 = false;



        //    //Ячейка амулета
        //    if (allItems[17] != null && (!state17))
        //    {
        //        goS = Instantiate(allItems[15].GetComponent<Item>().objItem) as GameObject;
        //        goS.transform.parent = GameObject.Find("Armor").transform;
        //        goS.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //        goS.transform.localPosition = new Vector3(0, 0, 0);
        //        gameObject.GetComponent<Skills>().dam += allItems[16].GetComponent<Item>().Agility;
        //        state15 = true;

        //    }

        //    if (allItems[17] == null) && (!state17))
        //        {

        //        gameObject.GetComponent<Skills>.dam = 0;
        //        state15 = false;
//            }
        

}
