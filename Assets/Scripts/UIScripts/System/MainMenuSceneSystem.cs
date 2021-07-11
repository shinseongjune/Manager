using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneSystem : MonoBehaviour
{
    public void NewGame()
    {
        if (GameManager.Instance.CreateNewGame())
        {
            SceneManager.LoadScene("Outer", LoadSceneMode.Single);
        }
        else
        {
            //TODO: 게임 생성 실패 경고창(ui패널)
        }

    }

    public void LoadGame(int gameId)
    {
        //TODO: 게임 불러오기
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
