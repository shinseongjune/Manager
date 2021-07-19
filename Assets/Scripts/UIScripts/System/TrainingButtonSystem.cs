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

    //TODO: ���𺰷� �Ʒ� ������. �Ʒ� ��ư �ڵ� ����. �Ƹ� trainingcontentssystem����
    [SerializeField]
    PLAN_TYPE type;

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
            PlanImageComponent sic;
            if (sic = results[0].gameObject.GetComponent<PlanImageComponent>())
            {
                int id = sic.id;
                trainingContentsSystem.SetPlan(id);
                trainingContentsSystem.PageLoad();
            }
            else if (results[0].gameObject.name == "Everyone")
            {
                trainingContentsSystem.SetPlanEveryone();
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

    //����======================
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
