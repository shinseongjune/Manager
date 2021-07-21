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
        moneyText.text = "�ܰ�: " + gameData.teams[1].money.ToString() + "��"; //TODO: ���� ���� comma �ִ� Ȯ��޼ҵ�?
    }
}
