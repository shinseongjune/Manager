public class Player
{
    public int id;

    public string firstName;
    public string LastName;
    public int age;

    public int aggression; // ���ݼ�. 1�� ������ 2%, ȸ���� 1%, HP -0.5%
    public int stamina; // ü��. 1�� HP 1%, (���� ü�� / �⺻ ü��) * 0.1 ��ŭ ��� ���ȿ� ���ʽ�
    public int dexterity; // ��ø��. 1�� ĳ���� �ӵ� 0.5%, ȸ�� �ӵ� 2%, ���� �ӵ� 0.5%, ü�� �Ҹ� 10% ����
    public int intellect; // ����. 1�� ȿ�� ���� 1%, ���ӽð� 2%, ĳ���� �ӵ� 0.5%, ��Ÿ�� ���� 0.5%, MP �Ҹ� 0.5% ����
    public int resolve; //��ܷ�. 1�� ���� �ӵ� 2%, ĳ���� �ӵ� 1%, HP -0.5%, MP �Ҹ� 1% ����

    public int nowStamina; // ���� ü��.

    public int fame = 0; // �α�

    public int team = -1; // -1 = ���Ҽ�

    public SCHEDULE_TYPE schedule = SCHEDULE_TYPE.REST;
}
