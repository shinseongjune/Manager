using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpperBarSystem : MonoBehaviour
{
    [SerializeField]
    Text dateText;

    GameData gameData;

    private void Awake()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        WriteDate();
    }

    void WriteDate()
    {
        Date d = gameData.date;
        dateText.text = d.year + "³â " + d.month + "¿ù";
    }

    void ProgressDate()
    {
        gameData.date++;
    }
}
