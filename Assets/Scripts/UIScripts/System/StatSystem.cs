using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    string textContents;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        textContents = " " + GetComponent<StatComponent>().type + " : ";
        text.text = textContents;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        string desc = GetComponent<StatComponent>().desc;
        UIManager.Instance.ShowTooltip(desc);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.HideTooltip();
    }
}
