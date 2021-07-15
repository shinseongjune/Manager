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

    void WriteDate()
    {
        Date d = gameData.date;
        dateText.text = d.year + "년 " + d.month + "월 " + d.quarter + "분기";
    }
}
