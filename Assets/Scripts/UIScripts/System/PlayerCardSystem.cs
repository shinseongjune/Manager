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
            stats.Find("Personal").Find("Name").GetComponent<Text>().text = player.LastName + " " + player.firstName;
            stats.Find("Personal").Find("Age").GetComponent<Text>().text = player.age + "세";
            stats.Find("Ability").Find("AggressionImage").Find("AggressionText").GetComponent<Text>().text = " 공격성 : " + player.aggression.ToString();
            stats.Find("Ability").Find("StaminaImage").Find("StaminaText").GetComponent<Text>().text = " 체력 : " + player.stamina.ToString();
            stats.Find("Ability").Find("DexterityImage").Find("DexterityText").GetComponent<Text>().text = " 민첩성 : " + player.dexterity.ToString();
            stats.Find("Ability").Find("IntellectImage").Find("IntellectText").GetComponent<Text>().text = " 지능 : " + player.intellect.ToString();
            stats.Find("Ability").Find("ResolveImage").Find("ResolveText").GetComponent<Text>().text = " 결단력 : " + player.resolve.ToString();
            stats.Find("Ability").Find("FameImage").Find("FameText").GetComponent<Text>().text = " 인기 : " + player.fame.ToString();
        }
    }
}
