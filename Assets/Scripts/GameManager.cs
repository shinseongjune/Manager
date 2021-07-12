using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GameManager : MonoBehaviour
{
    const int NEW_GAME_PLAYER_COUNT = 300; // NEW_GAME_TEAM_COUNT * 8 �̻����� �ؾ���!
    const int NEW_GAME_TEAM_COUNT = 16;

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

    private void Start()
    {
        gameData = gameDataObject.GetComponent<GameData>();
    }

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
            //TODO: �� ����
            Dictionary<int, Team> teams = new Dictionary<int, Team>();
            id = 1;
            for (int i = 0; i < NEW_GAME_TEAM_COUNT; i++)
            {
                MakeRandomTeam(ref id, ref teams, ref players);
            }
            //GameData�� �Ѱ��ֱ�
            gameData.players = players;
            gameData.teams = teams;
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
        tempPlayer.atk = UnityEngine.Random.Range(3, 9);
        tempPlayer.def = UnityEngine.Random.Range(3, 9);
        tempPlayer.con = UnityEngine.Random.Range(3, 9);
        
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
            while (true)
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
}
