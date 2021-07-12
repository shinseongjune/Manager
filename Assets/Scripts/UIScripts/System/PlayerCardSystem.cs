using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerCardSystem : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Player player = GetComponent<PlayerCardComponent>().player;
            GameObject.Find("MainUI").transform.Find("Stats").gameObject.SetActive(true);
            Transform stats = GameObject.Find("Stats").transform;
            stats.Find("Name").GetComponent<Text>().text = player.LastName + " " + player.firstName;
            stats.Find("Age").GetComponent<Text>().text = player.age + "세";
            stats.Find("ATKText").GetComponent<Text>().text = "공격력 : " + player.atk.ToString();
            stats.Find("DEFText").GetComponent<Text>().text = "방어력 : " + player.def.ToString();
            stats.Find("CONText").GetComponent<Text>().text = "체력 : " + player.con.ToString();
        }
    }
}
