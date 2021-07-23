using System;

public class TrainingGround
{
    //singleton=========================================================
    private static readonly TrainingGround instance = new TrainingGround();

    static TrainingGround()
    {

    }

    private TrainingGround()
    {

    }

    public static TrainingGround Instance
    {
        get
        {
            return instance;
        }
    }
    //===================================================================

    public void DoTraining(ref Player player)
    {
        switch (player.plan)
        {
            case PLAN_TYPE.REST:
                DoRest(ref player);
                break;
            case PLAN_TYPE.COMBAT_PRACTICE:
                DoCombatPractice(ref player);
                break;
            case PLAN_TYPE.EXERCISE:
                DoExercise(ref player);
                break;
            case PLAN_TYPE.AIMING_PRACTICE:
                DoAimingPractice(ref player);
                break;
            case PLAN_TYPE.STRATEGY_STUDY:
                DoStrategyStudy(ref player);
                break;
            case PLAN_TYPE.HERO_MOVIE:
                DoHeroMovie(ref player);
                break;
        }
    }
    private static void DoRest(ref Player player)
    {
        //player.nowStamina += Math.Min((int)Math.Round(player.stamina * 0.7f), player.stamina - player.nowStamina);
        player.nowStamina = player.stamina;
    }

    private static void DoCombatPractice(ref Player player)
    {
        player.aggression += 1;
        player.nowStamina -= 1;
    }

    private static void DoExercise(ref Player player)
    {
        player.stamina += 1;
        player.nowStamina += 1;
    }

    private static void DoAimingPractice(ref Player player)
    {
        player.dexterity += 1;
        player.nowStamina -= 1;
    }

    private static void DoStrategyStudy(ref Player player)
    {
        player.intellect += 1;
        player.nowStamina -= 1;
    }

    private static void DoHeroMovie(ref Player player)
    {
        player.resolve += 1;
        player.nowStamina -= 1;
    }
}
