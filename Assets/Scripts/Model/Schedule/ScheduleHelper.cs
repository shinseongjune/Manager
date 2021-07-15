public static class ScheduleHelper
{
    public static string ToString(SCHEDULE_TYPE type)
    {
        string tempstr = "";
        switch (type)
        {
            case SCHEDULE_TYPE.REST:
                tempstr = "휴식";
                break;
            case SCHEDULE_TYPE.COMBAT_PRACTICE:
                tempstr = "전투 훈련";
                break;
            case SCHEDULE_TYPE.EXERCISE:
                tempstr = "체력 단련";
                break;
            case SCHEDULE_TYPE.AIMING_PRACTICE:
                tempstr = "에이밍 연습";
                break;
            case SCHEDULE_TYPE.STRATEGY_STUDY:
                tempstr = "전략 공부";
                break;
            case SCHEDULE_TYPE.HERO_MOVIE:
                tempstr = "히어로 영화 감상";
                break;
        }
        return tempstr;
    }
}
