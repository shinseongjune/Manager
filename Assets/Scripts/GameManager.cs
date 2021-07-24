using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GameManager : MonoBehaviour
{
    const int NEW_GAME_PLAYER_COUNT = 1200; // NEW_GAME_TEAM_COUNT * 8 �̻����� �ؾ���!
    const int NEW_GAME_TEAM_COUNT = 64;

    //singleton==============================
    static GameManager gameManagerInstance = null;

    public static GameManager Instance
    {
        get
        {
            return gameManagerInstance;
        }
    }

    private void Awake()
    {
        if (null == gameManagerInstance)
        {
            gameManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //=======================================

    [SerializeField]
    GameObject gameDataObject;
    GameData gameData;

    LeagueManager leagueManager = LeagueManager.Instance;

    private void Start()
    {
        gameData = gameDataObject.GetComponent<GameData>();
    }

    //�� ���� �޼ҵ�=============================================
    public bool CreateNewGame()
    {
        bool ret = true;

        try
        {
            //�÷��̾� ����(�����ؾ���)
            Dictionary<int, Player> players = new Dictionary<int, Player>();
            int id = 1;
            for (int i = 0; i < NEW_GAME_PLAYER_COUNT; i++)
            {
                MakeRandomPlayer(ref id, ref players);
            }
            //TODO: �� ����// �÷��̾� �� ���� �߰�, ��� ���� �߰�.
            Dictionary<int, Team> teams = new Dictionary<int, Team>();
            id = 1;
            for (int i = 0; i < NEW_GAME_TEAM_COUNT; i++)
            {
                MakeRandomTeam(ref id, ref teams, ref players);
            }
            //GameData�� ������ �Է�
            gameData.players = players;
            gameData.teams = teams;
            gameData.nowDate.year = 2021;
            gameData.nowDate.month = 1;
            gameData.nowDate.quarter = 1;

            //challange league ����
            gameData.teams[1].isInChallange = true;
            //������ ç�������׿� �߰� //TODO: �� ���� ������ ���� �� ������ ���׿� �߰��ؾ���.
            for(int i = 2; i <= 16; i++)
            {
                gameData.teams[i].isInChallange = true;
            }
        }
        catch (Exception e)
        {
            Debug.Log("New Game Creation Error! Stack Trace : " + e.StackTrace);
            ret = false;
        }

        return ret;
    }

    void MakeRandomPlayer(ref int id, ref Dictionary<int, Player> players)
    {
        Player tempPlayer = new Player();
        tempPlayer.id = id;
        //TODO: ���� �̸�, ���� //��ġ�� ���� const�� �����
        tempPlayer.firstName = "ö��";
        tempPlayer.LastName = "��";
        tempPlayer.age = UnityEngine.Random.Range(14, 22);
        //TODO: ����. 1�������� 1~4 ���� ����, 1���������� ���� ���� ������ �ٸ����ؼ� �� ����
        tempPlayer.aggression = UnityEngine.Random.Range(20, 50);
        tempPlayer.stamina = UnityEngine.Random.Range(20, 50);
        tempPlayer.dexterity = UnityEngine.Random.Range(20, 50);
        tempPlayer.intellect = UnityEngine.Random.Range(20, 50);
        tempPlayer.resolve = UnityEngine.Random.Range(20, 50);

        tempPlayer.nowStamina = tempPlayer.stamina; // ���� ü�� = �ִ� ü��
        
        //���� ��Ͽ� �߰�
        players.Add(id, tempPlayer);
        id++;
    }

    void MakeRandomTeam(ref int id, ref Dictionary<int, Team> teams, ref Dictionary<int, Player> players)
    {
        Team tempTeam = new Team();
        tempTeam.id = id;
        //TODO: �� �̸�
        tempTeam.name = "�ӽ���" + id;
        //�Ҽ� ����
        int cnt = UnityEngine.Random.Range(5, 9); //���� ����
        for(int i = 0; i < cnt; i++) //������ ���� �Ҵ�
        {
            while (true) // ���� ���� ������ ��� ���ѷ��� ����!
            {
                int playerId = UnityEngine.Random.Range(1, NEW_GAME_PLAYER_COUNT + 1);
                if(players[playerId].team < 1)
                {
                    tempTeam.players.Add(playerId);
                    players[playerId].team = id;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        teams.Add(id, tempTeam);
        id++;
    }
    //=============================================================

    //TODO: ���� ��ư ������ Ȯ��â->Ȯ���ϸ� progressdate()
    public void ProgressDate()
    {
        //->TODO: �������!!!

        //TODO: ������ �� �� ����->(�Ʒù���, ���� ���� ����(���״� �� �� �����Ұ�), �÷��̾� ���� ģ����� ��û?, 
        //TODO: ->���� �Ҽӵ��� ���� player�� �Ʒù���, ��� ����? ������� ���̳� ���谰���� ���� �켱������.

        for(int i = 1; i <= gameData.teams.Count; i++)
        {
            Team team = gameData.teams[i];
            for(int j = 0; j < team.players.Count; j++)
            {
                int playerId = team.players[j];
                Player player = gameData.players[playerId];
                TrainingGround.Instance.DoTraining(ref player);
            }
        }
        gameData.nowDate++;
        //�ذ� ���� ���->���� ����
        //->���� ����. �ذ� ���� ���? ����?
        //->���ǿ� ���� ������ ���� ����
        //->���̿� ���� ���� ��ȭ

        // ������ ��¥�� ���� ���
        //ç���� ���� 8�� 3�б� TODO:�ش� date�� const�� �����
        if(gameData.nowDate.month == 8 && gameData.nowDate.quarter == 3)
        {
            //������ Ȯ��
            List<int> challTeams = new List<int>();
            for(int i = 1; i <= gameData.teams.Count; i++)
            {
                if (gameData.teams[i].isInChallange) challTeams.Add(i);
            }
            if (challTeams.Count < 16)
            {
                //TODO:��� ��ŭ �� �� ����� ������Ű��
            }
            leagueManager.CreateLeague(gameData.nowDate, GAME_TYPE.CHALLANGE, challTeams);
        }
        //TODO:ga����
        //TODO:è��

        //TODO:�ƹ� ���׵� ���� ���ϰų� ���� ���� �� ��ü.
        //TODO: ���� ���============>

        //ȭ�� ���ε�
        GameObject.Find("UIManager").GetComponent<UIManager>().WriteDate();
        GameObject.Find("UIManager").GetComponent<UIManager>().ClickHomeButton();
    }
}
