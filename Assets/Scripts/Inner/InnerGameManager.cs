using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerGameManager
{
    //singleton=========================================================
    private static readonly InnerGameManager instance = new InnerGameManager();

    static InnerGameManager()
    {

    }

    private InnerGameManager()
    {

    }

    public static InnerGameManager Instance
    {
        get
        {
            return instance;
        }
    }
    //===================================================================

    public int playerTeam = -1;
}
