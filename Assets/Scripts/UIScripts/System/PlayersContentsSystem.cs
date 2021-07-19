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
        MAX_PAGE = gameData.GetComponent<GameData>().teams[1].players.Count / PLAYERS_IN_ONE_PAGE + (gameData.GetComponent<GameData>().teams[1].players.Count % PLAYERS_IN_ONE_PAGE == 0 ? 0 : 1);
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
            Text aggressionText = playerObject.transform.Find("PlayerDesc").Find("AggressionText").GetComponent<Text>();
            Text staminaText = playerObject.transform.Find("PlayerDesc").Find("StaminaText").GetComponent<Text>();
            Text dexterityText = playerObject.transform.Find("PlayerDesc").Find("DexterityText").GetComponent<Text>();
            Text intellectText = playerObject.transform.Find("PlayerDesc").Find("IntellectText").GetComponent<Text>();
            Text resolveText = playerObject.transform.Find("PlayerDesc").Find("ResolveText").GetComponent<Text>();
            playerObject.GetComponent<PlayerCardComponent>().player = player;

            //선수 카드 텍스트 입력
            nameText.text = player.LastName + " " + player.firstName;
            ageText.text = player.age + "세";
            aggressionText.text = "공격성: " + player.aggression;
            staminaText.text = "체력: " + player.stamina;
            dexterityText.text = "민첩성: " + player.dexterity;
            intellectText.text = "지능: " + player.intellect;
            resolveText.text = "결단력: " + player.resolve;

            //선수 카드 위치 조정
            switch (playerIndexInPage)
            {
                case 0:
                case 3:
                case 6:
                    playerObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector3(20 + (553 * (playerIndexInPage / 3)), -20, 0);
                    break;
                case 1:
                case 4:
                case 7:
                    playerObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector3(20 + (553 * (playerIndexInPage / 3)), -20 - 184, 0);
                    break;
                case 2:
                case 5:
                case 8:
                    playerObject.GetComponent<Image>().rectTransform.anchoredPosition = new Vector3(20 + (553 * (playerIndexInPage / 3)), -20 - 184 - 184, 0);
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
