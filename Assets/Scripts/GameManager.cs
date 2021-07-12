using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GameManager : MonoBehaviour
{
    const int NEW_GAME_PLAYER_COUNT = 300; // NEW_GAME_TEAM_COUNT * 8 이상으로 해야함!
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
            //플레이어 생성(수정해야함)
            Dictionary<int, Player> players = new Dictionary<int, Player>();
            int id = 1;
            for (int i = 0; i < NEW_GAME_PLAYER_COUNT; i++)
            {
                MakeRandomPlayer(ref id, ref players);
            }
            //TODO: 팀 생성
            Dictionary<int, Team> teams = new Dictionary<int, Team>();
            id = 1;
            for (int i = 0; i < NEW_GAME_TEAM_COUNT; i++)
            {
                MakeRandomTeam(ref id, ref teams, ref players);
            }
            //GameData에 넘겨주기
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
        //TODO: 선수 이름, 나이 //수치들 전부 const로 만들것
        tempPlayer.firstName = "철수";
        tempPlayer.LastName = "김";
        tempPlayer.age = UnityEngine.Random.Range(14, 22);
        //TODO: 스탯. 1차적으로 1~4 정도 선택, 1차랜덤값에 따라 랜덤 범위를 다르게해서 값 선택
        tempPlayer.atk = UnityEngine.Random.Range(3, 9);
        tempPlayer.def = UnityEngine.Random.Range(3, 9);
        tempPlayer.con = UnityEngine.Random.Range(3, 9);
        
        //선수 목록에 추가
        players.Add(id, tempPlayer);
        id++;
    }

    void MakeRandomTeam(ref int id, ref Dictionary<int, Team> teams, ref Dictionary<int, Player> players)
    {
        Team tempTeam = new Team();
        tempTeam.id = id;
        //TODO: 팀 이름
        tempTeam.name = "임시팀" + id;
        //소속 선수
        int cnt = UnityEngine.Random.Range(5, 9); //선수 숫자
        for(int i = 0; i < cnt; i++) //무작위 선수 할당
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
