using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    //singleton======================
    static GameData gameDataInstance = null;

    public static GameData Instance
    {
        get
        {
            return gameDataInstance;
        }
    }

    private void Awake()
    {
        if (null == gameDataInstance)
        {
            gameDataInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //=================================

    public Dictionary<int, Player> players;
    public Dictionary<int, Team> teams;
    

}
