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
                    ret = "ģ�� ���";
                    break;
                case GAME_TYPE.CHAMPS:
                    ret = "è�Ǿ� ����";
                    break;
                case GAME_TYPE.GA:
                    ret = "GA ���θ���";
                    break;
                case GAME_TYPE.CHALLANGE:
                    ret = "ç���� ����";
                    break;
            }

            return ret;
        }
    }
}