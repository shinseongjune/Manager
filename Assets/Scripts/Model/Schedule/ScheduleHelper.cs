public static class ScheduleHelper
{
    public static string ToString(SCHEDULE_TYPE type)
    {
        string tempstr = "";
        switch (type)
        {
            case SCHEDULE_TYPE.REST:
                tempstr = "�޽�";
                break;
            case SCHEDULE_TYPE.COMBAT_PRACTICE:
                tempstr = "���� �Ʒ�";
                break;
            case SCHEDULE_TYPE.EXERCISE:
                tempstr = "ü�� �ܷ�";
                break;
            case SCHEDULE_TYPE.AIMING_PRACTICE:
                tempstr = "���̹� ����";
                break;
            case SCHEDULE_TYPE.STRATEGY_STUDY:
                tempstr = "���� ����";
                break;
            case SCHEDULE_TYPE.HERO_MOVIE:
                tempstr = "����� ��ȭ ����";
                break;
        }
        return tempstr;
    }
}
