using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Extensions;

public class ScheduleMonthSystem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject schedulePrefab;

    [SerializeField]
    GameObject schedulePrefabWrapper;

    GameObject schedulesWindow;
    ScheduleMonthComponent scheduleMonthComponent;
    GameData gameData;
    ScheduleContentsSystem scheduleContentsSystem;

    private void Awake()
    {
        schedulesWindow = transform.parent.parent.Find("SchedulesWindow").gameObject;
        scheduleMonthComponent = GetComponent<ScheduleMonthComponent>();
        gameData = GameData.Instance;
        scheduleContentsSystem = transform.parent.parent.GetComponent<ScheduleContentsSystem>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(schedulesWindow.activeInHierarchy) scheduleContentsSystem.DestroySchedulePrefabWrapper();

        schedulesWindow.SetActive(true);
        schedulesWindow.transform.Find("ScheduleWindowImage").Find("ScheduleWindowText").GetComponent<Text>().text = scheduleMonthComponent.month + "월 일정";

        List<Schedule> schedules = scheduleMonthComponent.schedules;

        Transform schedulesContent = schedulesWindow.transform.Find("SchedulesScrollView").Find("Viewport").Find("SchedulesContent");
        schedulesContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, schedules.Count * 110);
        
        GameObject spw = Instantiate(schedulePrefabWrapper);
        spw.transform.SetParent(schedulesContent);
        spw.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        spw.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        for(int i = 0; i < schedules.Count; i++)
        {
            Schedule s = schedules[i];
            GameObject sp = Instantiate(schedulePrefab);
            sp.transform.SetParent(spw.transform);
            sp.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, -10 - (110 * i));

            sp.transform.Find("QuarterText").GetComponent<Text>().text = s.date.quarter.ToString() + "분기";
            sp.transform.Find("LeagueNameText").GetComponent<Text>().text = s.game_type.GetString();

            string team1 = s.teams[0] == -1 ? "?" : gameData.teams[s.teams[0]].name;
            string team2 = s.teams[1] == -1 ? "?" : gameData.teams[s.teams[1]].name;

            sp.transform.Find("VSText").GetComponent<Text>().text = team1 + " vs " + team2;
        }
    }
}
