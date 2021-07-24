using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GameManager : MonoBehaviour
{
    const int NEW_GAME_PLAYER_COUNT = 1200; // NEW_GAME_TEAM_COUNT * 8 이상으로 해야함!
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

    //새 게임 메소드=============================================
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
            //TODO: 팀 생성// 플레이어 팀 생성 추가, 계약 생성 추가.
            Dictionary<int, Team> teams = new Dictionary<int, Team>();
            id = 1;
            for (int i = 0; i < NEW_GAME_TEAM_COUNT; i++)
            {
                MakeRandomTeam(ref id, ref teams, ref players);
            }
            //GameData에 데이터 입력
            gameData.players = players;
            gameData.teams = teams;
            gameData.nowDate.year = 2021;
            gameData.nowDate.month = 1;
            gameData.nowDate.quarter = 1;

            //challange league 참가
            gameData.teams[1].isInChallange = true;
            //적당히 챌린지리그에 추가 //TODO: 팀 수준 나눠서 생성 후 적절한 리그에 추가해야함.
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
        //TODO: 선수 이름, 나이 //수치들 전부 const로 만들것
        tempPlayer.firstName = "철수";
        tempPlayer.LastName = "김";
        tempPlayer.age = UnityEngine.Random.Range(14, 22);
        //TODO: 스탯. 1차적으로 1~4 정도 선택, 1차랜덤값에 따라 랜덤 범위를 다르게해서 값 선택
        tempPlayer.aggression = UnityEngine.Random.Range(20, 50);
        tempPlayer.stamina = UnityEngine.Random.Range(20, 50);
        tempPlayer.dexterity = UnityEngine.Random.Range(20, 50);
        tempPlayer.intellect = UnityEngine.Random.Range(20, 50);
        tempPlayer.resolve = UnityEngine.Random.Range(20, 50);

        tempPlayer.nowStamina = tempPlayer.stamina; // 현재 체력 = 최대 체력
        
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
            while (true) // 선수 수가 부족할 경우 무한루프 주의!
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

    //TODO: 진행 버튼 누르면 확인창->확인하면 progressdate()
    public void ProgressDate()
    {
        //->TODO: 경기진행!!!

        //TODO: 나머지 팀 턴 진행->(훈련배정, 리그 참가 여부(리그당 팀 수 제한할것), 플레이어 팀에 친선경기 신청?, 
        //TODO: ->팀에 소속되지 않은 player들 훈련배정, 희망 연봉? 가고싶은 팀이나 관계같은건 낮은 우선순위로.

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
        //해가 변한 경우->나이 진행
        //->은퇴 진행. 해가 변한 경우? 랜덤?
        //->조건에 따라 무작위 선수 생성
        //->나이에 따른 스탯 변화

        // 지정된 날짜에 리그 출범
        //챌린지 리그 8월 3분기 TODO:해당 date들 const로 만들것
        if(gameData.nowDate.month == 8 && gameData.nowDate.quarter == 3)
        {
            //참가팀 확인
            List<int> challTeams = new List<int>();
            for(int i = 1; i <= gameData.teams.Count; i++)
            {
                if (gameData.teams[i].isInChallange) challTeams.Add(i);
            }
            if (challTeams.Count < 16)
            {
                //TODO:비는 만큼 새 팀 만들어 참가시키기
            }
            leagueManager.CreateLeague(gameData.nowDate, GAME_TYPE.CHALLANGE, challTeams);
        }
        //TODO:ga리그
        //TODO:챔스

        //TODO:아무 리그도 참가 안하거나 빚이 많은 팀 해체.
        //TODO: 뉴스 등등============>

        //화면 리로드
        GameObject.Find("UIManager").GetComponent<UIManager>().WriteDate();
        GameObject.Find("UIManager").GetComponent<UIManager>().ClickHomeButton();
    }
}
