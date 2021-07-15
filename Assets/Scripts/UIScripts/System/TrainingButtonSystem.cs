using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrainingButtonSystem : MonoBehaviour, IDeselectHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Canvas canvas;
    GraphicRaycaster gr;
    PointerEventData ped;

    [SerializeField]
    GameObject trainingContentsSystemGo;

    TrainingContentsSystem trainingContentsSystem;

    //TODO: 시즌별로 훈련 나누기. 훈련 버튼 자동 생성. 아마 trainingcontentssystem에서
    [SerializeField]
    SCHEDULE_TYPE type;

    private void Start()
    {
        trainingContentsSystem = trainingContentsSystemGo.GetComponent<TrainingContentsSystem>();
        gr = canvas.GetComponent<GraphicRaycaster>();
        ped = new PointerEventData(null);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(ped, results);

        if(results.Count > 0)
        {
            ScheduleImageComponent sic;
            if (sic = results[0].gameObject.GetComponent<ScheduleImageComponent>())
            {
                int id = sic.id;
                trainingContentsSystem.SetSchedule(id);
                trainingContentsSystem.PageLoad();
            }
            else if (results[0].gameObject.name == "Everyone")
            {
                trainingContentsSystem.SetScheduleEveryone();
            }
            else
            {
                trainingContentsSystem.isTrainingButtonOn = false;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        trainingContentsSystem.isTrainingButtonOn = true;
        trainingContentsSystem.trainingButtonType = type;
    }

    //툴팁======================
    public void OnPointerEnter(PointerEventData eventData)
    {
        string desc = GetComponent<DescComponent>().desc;
        UIManager.Instance.ShowTooltip(desc);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.HideTooltip();
    }
    //=========================
}
