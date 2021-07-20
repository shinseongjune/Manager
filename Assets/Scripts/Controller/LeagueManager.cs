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

    
    public void CreateLeague(Date date, GAME_TYPE type, List<int> teams)
    {
        GameData gameData = GameData.Instance;
        Date date1 = new Date(date.year, date.month, date.quarter);
        League league = new League();
        league.year = date1.year;
        league.type = type;
        league.teams = teams;
        
        if (teams.Count % 2 != 0) teams.Add(-1); // -1 = bye

        List<Schedule> schedules = new List<Schedule>();
        int gameCount = teams.Count * (teams.Count - 1) / 2;
        int roundCount = teams.Count - 1;
        int gamePerRound = gameCount / roundCount;

        //1번 팀이 없는 순회용 팀 리스트
        List<int> tempList = new List<int>();
        tempList.AddRange(teams);
        tempList.RemoveAt(0);
        int tempSize = tempList.Count;

        //스케줄 생성, 날짜 등록
        int dateOffset = 1;
        int gamesInOneDay = 0;
        Random r = new Random(DateTime.Now.Millisecond);
        for(int i = 0; i < gameCount; i++)
        {
            Schedule s = new Schedule();
            s.game_type = type;
            s.date = date1 + dateOffset;
            gamesInOneDay++;
            if(gamesInOneDay == gamePerRound)
            {
                dateOffset += (r.Next(1, 3));
                gamesInOneDay = 0;
            }
            schedules.Add(s);
        }
        
        //팀 등록
        for(int d = 0; d < roundCount; d++)
        {
            int teamIdx = d % tempSize;

            int idx = 0 + gamePerRound * d;
            schedules[idx].teams[0] = teams[0];
            schedules[idx].teams[1] = tempList[teamIdx];
            idx++;

            for(; idx < Math.Min(gamePerRound * (d + 1), schedules.Count); idx++)
            {
                int firstTeam = (d + idx) % tempSize;
                int secondTeam = Math.Abs((d + tempSize - idx)) % tempSize;
                schedules[idx].teams[0] = tempList[firstTeam];
                schedules[idx].teams[1] = tempList[secondTeam];
            }
        }

        //플레이오프 일정. 상위 5개팀.
        dateOffset++;
        for(int i = 0; i < 4; i++)
        {
            dateOffset++;
            Schedule s = new Schedule();
            s.game_type = type;
            s.date = date1 + dateOffset;
        }

        league.schedules = schedules;
        gameData.challange = league;
        gameData.schedules.AddRange(schedules);
        gameData.schedules.Sort((x, y) => x.date.CompareTo(y.date));
    }
}
