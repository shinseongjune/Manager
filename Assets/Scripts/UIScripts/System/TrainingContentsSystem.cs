using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Extensions;

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

    //�Ʒ� ������ ��� ���� ����
    public bool isTrainingButtonOn = false;
    public PLAN_TYPE trainingButtonType;
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
            //���� ��������
            Player player = gd.players[playerTeam.players[i]];
            //���� ī�� ���� �� �ؽ�Ʈ ��������
            GameObject playerObject = Instantiate(playerSlot);
            playerObject.transform.SetParent(playerWrapperObject.transform);
            Text playerNameText = playerObject.transform.Find("PlayerInfo").Find("PlayerNameText").GetComponent<Text>();
            Text playerAgeText = playerObject.transform.Find("PlayerInfo").Find("PlayerAgeText").GetComponent<Text>();
            PlanImageComponent planImage = playerObject.transform.Find("PlanImage").GetComponent<PlanImageComponent>();
            PlanCancelButtonSystem planCancelButton = playerObject.transform.Find("PlanImage").Find("PlanCancelButton").GetComponent<PlanCancelButtonSystem>();
            Text planText = playerObject.transform.Find("PlanImage").Find("PlanText").GetComponent<Text>();
            playerObject.transform.Find("PlayerInfo").GetComponent<PlayerCardComponent>().player = player;

            //���� ī�� �ؽ�Ʈ �Է�
            playerNameText.text = player.LastName + " " + player.firstName;
            playerAgeText.text = player.age + "��";
            planImage.id = player.id;
            planCancelButton.id = player.id;
            planText.text = player.plan.GetString();
            if (player.plan != PLAN_TYPE.REST)
            {
                playerObject.transform.Find("PlanImage").Find("PlanCancelButton").gameObject.SetActive(true);
            }
            else
            {
                playerObject.transform.Find("PlanImage").Find("PlanCancelButton").gameObject.SetActive(false);
            }

            //���� ī�� ��ġ ����
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

    public void SetPlan(int id)
    {
        GameData gd = gameData.GetComponent<GameData>();
        gd.players[id].plan = trainingButtonType;
    }

    public void SetPlanEveryone()
    {
        GameData gd = gameData.GetComponent<GameData>();
        for(int i = 0; i < gd.teams[1].players.Count; i++)
        {
            int id = gd.players[gd.teams[1].players[i]].id;
            SetPlan(id);
        }
        PageLoad();

    }

    public void CancelPlan(int id)
    {
        GameData gd = gameData.GetComponent<GameData>();
        gd.players[id].plan = PLAN_TYPE.REST;
    }

    public void CancelPlanEveryone()
    {
        GameData gd = gameData.GetComponent<GameData>();
        for (int i = 0; i < gd.teams[1].players.Count; i++)
        {
            int id = gd.players[gd.teams[1].players[i]].id;
            CancelPlan(id);
        }
        PageLoad();
    }
}
