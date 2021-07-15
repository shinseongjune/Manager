using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrainingContentsSystem : MonoBehaviour
{
    const int PLAYERS_IN_ONE_PAGE = 8;

    int nowPage = 1;

    [SerializeField]
    GameObject playerSlot;
    [SerializeField]
    GameObject playerWrapper;

    GameObject gameData;

    int MAX_PAGE;

    //훈련 스케줄 등록 관련 변수
    public bool isTrainingButtonOn = false;
    public SCHEDULE_TYPE trainingButtonType;
    //============================================

    private void Awake()
    {
        gameData = GameObject.Find("GameData");
        MAX_PAGE = gameData.GetComponent<GameData>().teams[1].players.Count / PLAYERS_IN_ONE_PAGE + (gameData.GetComponent<GameData>().teams[1].players.Count % PLAYERS_IN_ONE_PAGE == 0 ? 0 : 1);
    }

    public void PagePlus()
    {
        if (nowPage < MAX_PAGE) nowPage++;
    }

    public void PageMinus()
    {
        if (nowPage > 1) nowPage--;
    }

    public void DestroyPlayerClones()
    {
        GameObject wrapper = GameObject.FindGameObjectWithTag("PlayerWrapperForTraining");
        Destroy(wrapper);
    }

    public void PageLoad()
    {
        GameObject.Find("PageText").GetComponent<Text>().text = nowPage.ToString();

        GameData gd = gameData.GetComponent<GameData>();
        Team playerTeam = gd.teams[1];

        int firstPlayerNumber = (nowPage - 1) * PLAYERS_IN_ONE_PAGE;
        int lastPlayerNumber = PLAYERS_IN_ONE_PAGE * nowPage;

        if (playerTeam.players.Count < lastPlayerNumber) lastPlayerNumber = playerTeam.players.Count;

        GameObject playerWrapperObject = Instantiate(playerWrapper);
        playerWrapperObject.transform.SetParent(GameObject.Find("Players").transform);
        playerWrapperObject.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        playerWrapperObject.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        int playerIndexInPage = 0;
        for (int i = firstPlayerNumber; i < lastPlayerNumber; i++)
        {
            //선수 가져오기
            Player player = gd.players[playerTeam.players[i]];
            //선수 카드 생성 및 텍스트 가져오기
            GameObject playerObject = Instantiate(playerSlot);
            playerObject.transform.SetParent(playerWrapperObject.transform);
            Text playerNameText = playerObject.transform.Find("PlayerInfo").Find("PlayerNameText").GetComponent<Text>();
            Text playerAgeText = playerObject.transform.Find("PlayerInfo").Find("PlayerAgeText").GetComponent<Text>();
            ScheduleImageComponent scheduleImage = playerObject.transform.Find("ScheduleImage").GetComponent<ScheduleImageComponent>();
            ScheduleCancelButtonSystem scheduleCancelButton = playerObject.transform.Find("ScheduleImage").Find("ScheduleCancelButton").GetComponent<ScheduleCancelButtonSystem>();
            Text scheduleText = playerObject.transform.Find("ScheduleImage").Find("ScheduleText").GetComponent<Text>();
            playerObject.transform.Find("PlayerInfo").GetComponent<PlayerCardComponent>().player = player;

            //선수 카드 텍스트 입력
            playerNameText.text = player.LastName + " " + player.firstName;
            playerAgeText.text = player.age + "세";
            scheduleImage.id = player.id;
            scheduleCancelButton.id = player.id;
            scheduleText.text = ScheduleHelper.ToString(player.schedule);
            if(player.schedule != SCHEDULE_TYPE.REST)
            {
                playerObject.transform.Find("ScheduleImage").Find("ScheduleCancelButton").gameObject.SetActive(true);
            }
            else
            {
                playerObject.transform.Find("ScheduleImage").Find("ScheduleCancelButton").gameObject.SetActive(false);
            }

            //선수 카드 위치 조정
            switch (playerIndexInPage)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    playerObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector3(20 + (275 * (playerIndexInPage % 4)), -20, 0);
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                    playerObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector3(20 + (275 * (playerIndexInPage % 4)), -440, 0);
                    break;
            }
            playerIndexInPage++;
        }
    }

    public void PagePlusLoad()
    {
        PagePlus();
        DestroyPlayerClones();
        PageLoad();
    }

    public void PageMinusLoad()
    {
        PageMinus();
        DestroyPlayerClones();
        PageLoad();
    }

    public void ChangeMaxPage()
    {
        GameData gd = gameData.GetComponent<GameData>();
        Team playerTeam = gd.teams[1];
        MAX_PAGE = playerTeam.players.Count;
    }

    public void SetSchedule(int id)
    {
        GameData gd = gameData.GetComponent<GameData>();
        gd.players[id].schedule = trainingButtonType;
    }

    public void SetScheduleEveryone()
    {
        GameData gd = gameData.GetComponent<GameData>();
        for(int i = 0; i < gd.teams[1].players.Count; i++)
        {
            int id = gd.players[gd.teams[1].players[i]].id;
            SetSchedule(id);
        }
        PageLoad();

    }

    public void CancelSchedule(int id)
    {
        GameData gd = gameData.GetComponent<GameData>();
        gd.players[id].schedule = SCHEDULE_TYPE.REST;
    }

    public void CancelScheduleEveryone()
    {
        GameData gd = gameData.GetComponent<GameData>();
        for (int i = 0; i < gd.teams[1].players.Count; i++)
        {
            int id = gd.players[gd.teams[1].players[i]].id;
            CancelSchedule(id);
        }
        PageLoad();
    }
}
