namespace Extensions
{

    public static class SquadStatusHelper
    {
        public static string GetString(this SQUAD_STATUS status)
        {
                //TODO: ������ ���� ���� �߰��ϰ� ���� �������̽����� �߰��Ұ�
            string ret = "";
            switch (status)
            {
                case SQUAD_STATUS.KEY_PLAYER:
                    ret = "�ٽ� ����";
                    break;
                case SQUAD_STATUS.ROTATION:
                    ret = "��ü ����";
                    break;
                case SQUAD_STATUS.NOT_NEEDED:
                    ret = "�׿� ����";
                    break;
            }
            return ret;
        }
    }

}