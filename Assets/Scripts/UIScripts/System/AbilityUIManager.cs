using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUIManager : MonoBehaviour
{
    static AbilityUIManager AbilityUIManagerInstance = null;

    private void Awake()
    {
        if(null == AbilityUIManagerInstance)
        {
            AbilityUIManagerInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static AbilityUIManager Instance
    {
        get
        {
            if (null == AbilityUIManagerInstance)
            {
                return null;
            }
            return AbilityUIManagerInstance;
        }
    }

    private void Start()
    {
        tooltip.SetActive(false);
    }

    [SerializeField]
    private GameObject tooltip;

    public void ShowTooltip()
    {
        tooltip.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }
}
