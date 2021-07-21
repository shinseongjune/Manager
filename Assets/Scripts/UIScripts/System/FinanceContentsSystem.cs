using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinanceContentsSystem : MonoBehaviour
{
    GameData gameData;
    Text moneyText;

    void Awake()
    {
        gameData = GameData.Instance;
    }

    public void WriteMoney()
    {
        moneyText = transform.Find("MoneyText").GetComponent<Text>();
        moneyText.text = "잔고: " + gameData.teams[1].money.ToString() + "원"; //TODO: 숫자 사이 comma 넣는 확장메소드?
    }
}
