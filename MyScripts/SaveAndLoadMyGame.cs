using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]

public class Game
{

    public Game()
    {


    }

}
public  static class SaveAndLoadMyGame //: MonoBehaviour {
{

    public static List<Game> savedGames = new List<Game>();

    public static void Save()
    {   
        //savedGames.Add(Game.current);
        //BinaryFormatter bf1 = new BinaryFormatter();
        //FileStream file = 

    }


    public static void Load()
    {



    }

}
