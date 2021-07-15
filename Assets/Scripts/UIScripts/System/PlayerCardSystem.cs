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
            stats.Find("Personal").Find("Age").GetComponent<Text>().text = player.age + "��";
            stats.Find("Ability").Find("AggressionImage").Find("AggressionText").GetComponent<Text>().text = " ���ݼ� : " + player.aggression.ToString();
            stats.Find("Ability").Find("StaminaImage").Find("StaminaText").GetComponent<Text>().text = " ü�� : " + player.stamina.ToString();
            stats.Find("Ability").Find("DexterityImage").Find("DexterityText").GetComponent<Text>().text = " ��ø�� : " + player.dexterity.ToString();
            stats.Find("Ability").Find("IntellectImage").Find("IntellectText").GetComponent<Text>().text = " ���� : " + player.intellect.ToString();
            stats.Find("Ability").Find("ResolveImage").Find("ResolveText").GetComponent<Text>().text = " ��ܷ� : " + player.resolve.ToString();
            stats.Find("Ability").Find("FameImage").Find("FameText").GetComponent<Text>().text = " �α� : " + player.fame.ToString();
        }
    }
}
