using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //singleton=========================
    static UIManager UIManagerInstance = null;

    private void Awake()
    {
        if(null == UIManagerInstance)
        {
            UIManagerInstance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static UIManager Instance
    {
        get
        {
            if (null == UIManagerInstance)
            {
                return null;
            }
            return UIManagerInstance;
        }
    }
    //====================================

    private GameObject tooltip;

    [SerializeField]
    private GameObject tooltipPrefab;

    GameData gameData;

    private void Start()
    {
        MakeTooltipObject();
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
    }

    public void MakeTooltipObject()
    {
        tooltip = Instantiate(tooltipPrefab);
        tooltip.transform.SetParent(GameObject.Find("Canvas").transform);
        tooltip.SetActive(false);
    }


    public void ShowTooltip(string desc)
    {
        Tooltip tooltipScript = tooltip.GetComponent<Tooltip>();
        tooltipScript.FillDesc(desc);
        tooltip.SetActive(true);
    }

    public void HideTooltip()
    {
        Tooltip tooltipScript = tooltip.GetComponent<Tooltip>();
        tooltipScript.FillDesc("");
        tooltip.SetActive(false);
    }

    public void ProgressDate()
    {

    }
}
