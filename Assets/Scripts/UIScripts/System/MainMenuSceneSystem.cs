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
            //TODO: ���� ���� ���� ���â(ui�г�)
        }

    }

    public void LoadGame(int gameId)
    {
        //TODO: ���� �ҷ�����
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
