using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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

    private void Start()
    {
        tooltip.SetActive(false);
    }

    [SerializeField]
    private GameObject tooltip;

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
}
