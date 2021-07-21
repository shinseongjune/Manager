namespace Extensions
{

    public static class SquadStatusHelper
    {
        public static string GetString(this SQUAD_STATUS status)
        {
                //TODO: 선수에 선수 위상 추가하고 관련 인터페이스에도 추가할것
            string ret = "";
            switch (status)
            {
                case SQUAD_STATUS.KEY_PLAYER:
                    ret = "핵심 선수";
                    break;
                case SQUAD_STATUS.ROTATION:
                    ret = "교체 선수";
                    break;
                case SQUAD_STATUS.NOT_NEEDED:
                    ret = "잉여 선수";
                    break;
            }
            return ret;
        }
    }

}