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
                    tempstr = "�޽�";
                    break;
                case PLAN_TYPE.COMBAT_PRACTICE:
                    tempstr = "���� �Ʒ�";
                    break;
                case PLAN_TYPE.EXERCISE:
                    tempstr = "ü�� �ܷ�";
                    break;
                case PLAN_TYPE.AIMING_PRACTICE:
                    tempstr = "���̹� ����";
                    break;
                case PLAN_TYPE.STRATEGY_STUDY:
                    tempstr = "���� ����";
                    break;
                case PLAN_TYPE.HERO_MOVIE:
                    tempstr = "����� ��ȭ ����";
                    break;
            }
            return tempstr;
        }
    }

}