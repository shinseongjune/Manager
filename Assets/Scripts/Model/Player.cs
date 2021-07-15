public class Player
{
    public int id;

    public string firstName;
    public string LastName;
    public int age;

    public int aggression; // 공격성. 1당 데미지 2%, 회복량 1%, HP -0.5%
    public int stamina; // 체력. 1당 HP 1%, (현재 체력 / 기본 체력) * 0.1 만큼 모든 스탯에 보너스
    public int dexterity; // 민첩성. 1당 캐스팅 속도 0.5%, 회전 속도 2%, 공격 속도 0.5%, 체력 소모 10% 증가
    public int intellect; // 지능. 1당 효과 범위 1%, 지속시간 2%, 캐스팅 속도 0.5%, 쿨타임 감소 0.5%, MP 소모 0.5% 감소
    public int resolve; //결단력. 1당 공격 속도 2%, 캐스팅 속도 1%, HP -0.5%, MP 소모 1% 증가

    public int nowStamina; // 현재 체력.

    public int fame = 0; // 인기

    public int team = -1; // -1 = 무소속

    public SCHEDULE_TYPE schedule = SCHEDULE_TYPE.REST;
}
