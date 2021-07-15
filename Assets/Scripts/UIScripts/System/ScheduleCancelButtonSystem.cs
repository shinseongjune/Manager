using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleCancelButtonSystem : MonoBehaviour
{
    Button btn;
    public int id;

    TrainingContentsSystem tcs;

    private void Start()
    {
        tcs = GameObject.Find("TrainingContents").GetComponent<TrainingContentsSystem>();
        btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(delegate { tcs.CancelSchedule(id); });
        btn.onClick.AddListener(delegate { tcs.PageLoad(); });
    }
}
