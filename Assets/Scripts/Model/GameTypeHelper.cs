namespace Extensions
{
    public static class GameTypeHelper
    {
        public static string GetString(this GAME_TYPE type)
        {
            string ret = "";
            switch (type)
            {
                case GAME_TYPE.FRIENDLY:
                    ret = "친선 경기";
                    break;
                case GAME_TYPE.CHAMPS:
                    ret = "챔피언스 리그";
                    break;
                case GAME_TYPE.GA:
                    ret = "GA 프로리그";
                    break;
                case GAME_TYPE.CHALLANGE:
                    ret = "챌린지 리그";
                    break;
            }

            return ret;
        }
    }
}