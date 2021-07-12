using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersContentsSystem : MonoBehaviour
{
    const int PLAYERS_IN_ONE_PAGE = 9;

    int nowPage = 1;

    [SerializeField]
    GameObject playerSlot;
    [SerializeField]
    GameObject playerWrapper;

    GameObject gameData;

    int MAX_PAGE;

    private void Awake()
    {
        gameData = GameObject.Find("GameData");
        MAX_PAGE = gameData.GetComponent<GameData>().teams[1].players.Count / PLAYERS_IN_ONE_PAGE + 1;
    }

    public void PagePlus()
    {
        if(nowPage < MAX_PAGE) nowPage++;
    }

    public void PageMinus()
    {
        if(nowPage > 1) nowPage--;
    }

    public void DestroyPlayerClones()
    {
        GameObject wrapper = GameObject.FindGameObjectWithTag("PlayerWrapper");
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
        playerWrapperObject.transform.SetParent(GameObject.Find("PlayersContents").transform);
        playerWrapperObject.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        playerWrapperObject.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        int playerIndexInPage = 0;
        for(int i = firstPlayerNumber; i < lastPlayerNumber; i++)
        {
            //선수 가져오기
            Player player = gd.players[playerTeam.players[i]];
            //선수 카드 생성 및 텍스트 가져오기
            GameObject playerObject = Instantiate(playerSlot);
            playerObject.transform.SetParent(playerWrapperObject.transform);
            Text nameText = playerObject.transform.Find("PlayerDesc").Find("NameText").GetComponent<Text>();
            Text ageText = playerObject.transform.Find("PlayerDesc").Find("AgeText").GetComponent<Text>();
            Text atkText = playerObject.transform.Find("PlayerDesc").Find("ATKText").GetComponent<Text>();
            Text defText = playerObject.transform.Find("PlayerDesc").Find("DEFText").GetComponent<Text>();
            Text conText = playerObject.transform.Find("PlayerDesc").Find("CONText").GetComponent<Text>();

            //선수 카드 텍스트 입력
            nameText.text = player.LastName + " " + player.firstName;
            ageText.text = player.age + "세";
            atkText.text = "공격력: " + player.atk;
            defText.text = "방어력: " + player.def;
            conText.text = "체력: " + player.con;

            //선수 카드 위치 조정
            switch (playerIndexInPage)
            {
                case 0:
                case 1:
                case 2:
                    playerObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector3(20, -20 - (184 * (playerIndexInPage % 3)), 0);
                    break;
                case 3:
                case 4:
                case 5:
                    playerObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector3(20 + 553, -20 - (184 * (playerIndexInPage % 3)), 0);
                    break;
                case 6:
                case 7:
                case 8:
                    playerObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector3(20 + 553 + 553, -20 - (184 * (playerIndexInPage % 3)), 0);
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
}
