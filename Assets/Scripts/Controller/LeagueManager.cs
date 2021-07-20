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
        
        if (teams.Count % 2 != 0) teams.Add(-1); // -1 = bye

        List<Schedule> schedules = new List<Schedule>();
        int gameCount = teams.Count * (teams.Count - 1) / 2;
        int roundCount = teams.Count - 1;
        int gamePerRound = gameCount / roundCount;

        List<int> tempList = new List<int>();
        tempList.AddRange(teams);
        tempList.RemoveAt(0);
        int tempSize = tempList.Count;

        int dateOffset = 1;
        int gamesInOneDay = 0;
        for(int i = 0; i < gameCount; i++)
        {
            Schedule s = new Schedule();
            s.game_type = type;
            s.date = date + dateOffset;
            gamesInOneDay++;
            if(gamesInOneDay == gamePerRound)
            {
                dateOffset += 2;
                gamesInOneDay = 0;
            }
            schedules.Add(s);
        }
        
        for(int d = 0; d < roundCount; d++)
        {
            int teamIdx = d % tempSize;

            int idx = 0 + gamePerRound * d;
            schedules[idx].teams[0] = teams[0];
            schedules[idx].teams[1] = tempList[teamIdx];
            idx++;

            for(; idx < gamePerRound * (d + 1); idx++)
            {
                int firstTeam = (d + idx) % tempSize;
                int secondTeam = (d + tempSize - idx) % tempSize;
                schedules[idx].teams[0] = tempList[firstTeam];
                schedules[idx].teams[1] = tempList[secondTeam];
            }
        }

        league.schedules = schedules;
        gameData.schedules.AddRange(schedules);
        gameData.schedules.Sort((x, y) => x.date.CompareTo(y.date));
    }
}
