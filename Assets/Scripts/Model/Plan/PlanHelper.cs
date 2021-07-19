namespace Extensions
{
    public static class PlanHelper
    {
        public static string GetString(this PLAN_TYPE type)
        {
            string tempstr = "";
            switch (type)
            {
                case PLAN_TYPE.REST:
                    tempstr = "휴식";
                    break;
                case PLAN_TYPE.COMBAT_PRACTICE:
                    tempstr = "전투 훈련";
                    break;
                case PLAN_TYPE.EXERCISE:
                    tempstr = "체력 단련";
                    break;
                case PLAN_TYPE.AIMING_PRACTICE:
                    tempstr = "에이밍 연습";
                    break;
                case PLAN_TYPE.STRATEGY_STUDY:
                    tempstr = "전략 공부";
                    break;
                case PLAN_TYPE.HERO_MOVIE:
                    tempstr = "히어로 영화 감상";
                    break;
            }
            return tempstr;
        }
    }

}