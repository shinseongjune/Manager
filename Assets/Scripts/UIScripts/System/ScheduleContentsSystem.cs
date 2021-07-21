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
            WriteMonthScheduleData();
        }
    }

    public void NextYear()
    {
        if (year < gameData.nowDate.year + 2)
        {
            year++;
            WriteYear();
            WriteSchedules();
            WriteMonthScheduleData();
        }
    }

    public void WriteYear()
    {
        yearText.text = year + "년";
    }

    public void WriteSchedules()
    {
        List<Schedule> schedules = gameData.schedules;
        Transform scheduleWrapperTransform = transform.Find("ScheduleWrapper");
        //달력 클리어========================================================================================== TODO:wrapper 하나로 따로 묶고 수정필요
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

        Date d = new Date();
        for (int i = 0; i < schedules.Count; i++)
        {
            Schedule s = schedules[i];
            if(s.date.year < year)
            {
                continue;
            }
            if(s.date.year > year)
            {
                break;
            }
            if(s.date.CompareTo(d) == 0)
            {
                continue;
            }
            d = s.date;
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

    public void SetMonth()
    {
        Transform scheduleWrapperTransform = transform.Find("ScheduleWrapper");
        scheduleWrapperTransform.Find("Jan").GetComponent<ScheduleMonthComponent>().month = 1;
        scheduleWrapperTransform.Find("Fab").GetComponent<ScheduleMonthComponent>().month = 2;
        scheduleWrapperTransform.Find("Mar").GetComponent<ScheduleMonthComponent>().month = 3;
        scheduleWrapperTransform.Find("Apr").GetComponent<ScheduleMonthComponent>().month = 4;
        scheduleWrapperTransform.Find("May").GetComponent<ScheduleMonthComponent>().month = 5;
        scheduleWrapperTransform.Find("Jun").GetComponent<ScheduleMonthComponent>().month = 6;
        scheduleWrapperTransform.Find("Jul").GetComponent<ScheduleMonthComponent>().month = 7;
        scheduleWrapperTransform.Find("Aug").GetComponent<ScheduleMonthComponent>().month = 8;
        scheduleWrapperTransform.Find("Sep").GetComponent<ScheduleMonthComponent>().month = 9;
        scheduleWrapperTransform.Find("Oct").GetComponent<ScheduleMonthComponent>().month = 10;
        scheduleWrapperTransform.Find("Nov").GetComponent<ScheduleMonthComponent>().month = 11;
        scheduleWrapperTransform.Find("Dec").GetComponent<ScheduleMonthComponent>().month = 12;
    }

    public void WriteMonthScheduleData()
    {
        List<Schedule> schedules = gameData.schedules;
        Transform scheduleWrapperTransform = transform.Find("ScheduleWrapper");

        scheduleWrapperTransform.Find("Jan").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("Fab").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("Mar").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("Apr").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("May").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("Jun").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("Jul").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("Aug").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("Sep").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("Oct").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("Nov").GetComponent<ScheduleMonthComponent>().schedules.Clear();
        scheduleWrapperTransform.Find("Dec").GetComponent<ScheduleMonthComponent>().schedules.Clear();

        for (int i = 0; i < schedules.Count; i++)
        {
            Schedule s = schedules[i];
            if (s.date.year < year)
            {
                continue;
            }
            if (s.date.year > year)
            {
                break;
            }

            int m = s.date.month;

            switch (m)
            {
                case 1:
                    scheduleWrapperTransform.Find("Jan").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 2:
                    scheduleWrapperTransform.Find("Fab").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 3:
                    scheduleWrapperTransform.Find("Mar").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 4:
                    scheduleWrapperTransform.Find("Apr").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 5:
                    scheduleWrapperTransform.Find("May").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 6:
                    scheduleWrapperTransform.Find("Jun").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 7:
                    scheduleWrapperTransform.Find("Jul").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 8:
                    scheduleWrapperTransform.Find("Aug").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 9:
                    scheduleWrapperTransform.Find("Sep").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 10:
                    scheduleWrapperTransform.Find("Oct").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 11:
                    scheduleWrapperTransform.Find("Nov").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
                case 12:
                    scheduleWrapperTransform.Find("Dec").GetComponent<ScheduleMonthComponent>().schedules.Add(s);
                    break;
            }
        }
    }

    public void DestroySchedulePrefabWrapper()
    {
        GameObject wrapper = transform.Find("SchedulesWindow").Find("SchedulesScrollView").Find("Viewport").Find("SchedulesContent").Find("SchedulePrefabWrapper(Clone)").gameObject;
        Destroy(wrapper);
    }
}
