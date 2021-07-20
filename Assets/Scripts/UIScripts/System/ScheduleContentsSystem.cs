using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleContentsSystem : MonoBehaviour
{
    GameData gameData;
    Text yearText;
    int year;

    void Awake()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
    }

    public void GetYear()
    {
        yearText = transform.Find("ScheduleYearText").GetComponent<Text>();
        year = gameData.nowDate.year;
    }

    public void PrevYear()
    {
        if (year > gameData.nowDate.year)
        {
            year--;
            WriteYear();
            WriteSchedules();
        }
    }

    public void NextYear()
    {
        if (year < gameData.nowDate.year + 2)
        {
            year++;
            WriteYear();
            WriteSchedules();
        }
    }

    public void WriteYear()
    {
        yearText.text = year + "년";
    }

    public void WriteSchedules()
    {
        int nowYear = year;
        List<Schedule> schedules = gameData.schedules;
        Transform scheduleWrapperTransform = transform.Find("ScheduleWrapper");
        //달력 클리어==========================================================================================
        scheduleWrapperTransform.Find("Jan").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jan").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jan").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jan").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Fab").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Fab").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Fab").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Fab").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Mar").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Mar").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Mar").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Mar").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Apr").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Apr").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Apr").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Apr").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("May").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("May").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("May").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("May").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jun").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jun").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jun").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jun").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jul").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jul").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jul").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Jul").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Aug").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Aug").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Aug").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Aug").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Sep").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Sep").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Sep").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Sep").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Oct").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Oct").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Oct").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Oct").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Nov").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Nov").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Nov").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Nov").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Dec").Find("QuarterWrapper").Find("1").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Dec").Find("QuarterWrapper").Find("2").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Dec").Find("QuarterWrapper").Find("3").Find("VSText").GetComponent<Text>().text = "";
        scheduleWrapperTransform.Find("Dec").Find("QuarterWrapper").Find("4").Find("VSText").GetComponent<Text>().text = "";

        //====================================================================================================
        for (int i = 0; i < schedules.Count; i++)
        {
            Schedule s = schedules[i];
            if(s.date.year != nowYear)
            {
                continue;
            }
            int m = s.date.month;
            int q = s.date.quarter;

            switch (m)
            {
                case 1:
                    Text vsText = scheduleWrapperTransform.Find("Jan").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    string team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    string team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 2:
                    vsText = scheduleWrapperTransform.Find("Fab").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 3:
                    vsText = scheduleWrapperTransform.Find("Mar").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 4:
                    vsText = scheduleWrapperTransform.Find("Apr").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 5:
                    vsText = scheduleWrapperTransform.Find("May").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 6:
                    vsText = scheduleWrapperTransform.Find("Jun").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 7:
                    vsText = scheduleWrapperTransform.Find("Jul").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 8:
                    vsText = scheduleWrapperTransform.Find("Aug").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 9:
                    vsText = scheduleWrapperTransform.Find("Sep").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 10:
                    vsText = scheduleWrapperTransform.Find("Oct").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 11:
                    vsText = scheduleWrapperTransform.Find("Nov").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
                case 12:
                    vsText = scheduleWrapperTransform.Find("Dec").Find("QuarterWrapper").Find(q.ToString()).Find("VSText").GetComponent<Text>();
                    team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
                    team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;
                    vsText.text = team1 + " vs " + team2;
                    break;
            }
        }
    }
}
