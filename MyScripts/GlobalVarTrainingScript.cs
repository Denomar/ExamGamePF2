using UnityEngine;
using System.Collections;

public class GlobalVarTrainingscript : MonoBehaviour {

    void Avake()
    {
        Global.stats = 40;

    }
}
public static class Global
{

    public static bool visable; // показывать  инвентарь
    public static int stats; // Номер ячейки подбираемого предмета
}