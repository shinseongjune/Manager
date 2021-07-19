using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpperBarSystem : MonoBehaviour
{
    [SerializeField]
    Text dateText;

    GameData gameData;

    private void Awake()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        WriteTeamName();
        WriteDate();
    }

    void WriteTeamName()
    {
        Text teamName = GameObject.Find("TeamName").GetComponent<Text>();
        teamName.text = gameData.teams[1].name;
    }

    public void WriteDate()
    {
        Date d = gameData.nowDate;
        dateText.text = d.year + "년 " + d.month + "월 " + d.quarter + "분기";
    }

    public void ClickHomeButton()
    {
        transform.Find("HomeButton").GetComponent<Button>().onClick.Invoke();
    }
}
