using System;
using System.Collections.Generic;

public class LeagueManager
{
    //singleton=========================================================
    private static readonly LeagueManager instance = new LeagueManager();

    static LeagueManager()
    {

    }

    private LeagueManager()
    {

    }

    public static LeagueManager Instance
    {
        get
        {
            return instance;
        }
    }
    //===================================================================

    GameData gameData = GameData.Instance;
    
    public void CreateLeague(Date date, GAME_TYPE type, List<int> teams)
    {
        League league = new League();
        league.year = date.year;
        league.type = type;
        league.teams = teams;

        List<Schedule> schedules = new List<Schedule>();
        int gameCount = teams.Count * (teams.Count - 1) / 2;
        for(int i = 0; i < gameCount; i++)
        {
            Schedule s = new Schedule();
            s.game_type = type;
            schedules.Add(s);
        }

        int offset = 0;
        for(int i = 0; i < schedules.Count; i += 2)
        {
            schedules[i].date = date + offset++;
        }
        offset = 0;
        for(int i = 1; i < schedules.Count; i += 2)
        {
            schedules[i].date = date + offset++;
        }
    }
}
