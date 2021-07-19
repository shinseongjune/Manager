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

    public Date nowDate = new Date();

    public League Champs;
    public League GA;
    public League challange;

    public List<Schedule> schedules = new List<Schedule>();

}
