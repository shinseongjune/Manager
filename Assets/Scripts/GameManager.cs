using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GameManager : MonoBehaviour
{
    static GameManager gameManagerInstance = null;

    Dictionary<int, string> players;

    public static GameManager Instance
    {
        get
        {
            return gameManagerInstance;
        }
    }

    private void Awake()
    {
        if (null == gameManagerInstance)
        {
            gameManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool CreateNewGame()
    {
        bool ret = true;
        //세이브 폴더
        string dirPath;
        dirPath = Application.dataPath + "/save";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        string source = "";
        //플레이어 생성 (수정해야함)
        players = new Dictionary<int, string>();
        int id = 1;
        for(int i = 0; i < 100; i++)
        {
            source += MakeRandomPlayer(ref id, ref players);
        }
        //TODO: 팀 생성

        //임시 새 게임 파일 작성 
        FileStream fs = new FileStream(Application.dataPath + "/save/tempNewGame.json", FileMode.Create);
        byte[] info = new UTF8Encoding(true).GetBytes(source);
        try
        {
            fs.Write(info, 0, info.Length);
        }
        catch (Exception e)
        {
            Debug.Log("New Game Creation Exception! Stack Trace: " + e.StackTrace);
            ret = false;
        }
        finally
        {
            fs.Close();
        }
        return ret;
    }

    string MakeRandomPlayer(ref int id, ref Dictionary<int, string> players)
    {
        //선수 id number
        StringBuilder ret = new StringBuilder(id.ToString());
        ret.Append(" ");
        //TODO: 선수 이름
        ret.Append("김");
        ret.Append(" ");
        ret.Append("철수");
        ret.Append(" ");
        //TODO: 스탯. 1차적으로 1~4 정도 선택, 1차랜덤값에 따라 랜덤 범위를 다르게해서 값 선택
        ret.Append(UnityEngine.Random.Range(3,8) + " "); //공
        ret.Append(UnityEngine.Random.Range(3, 8) + " "); //방
        ret.Append(UnityEngine.Random.Range(3, 8) + " "); //체

        ret.Append("\n");
        string retStr = ret.ToString();
        //선수 목록에 추가
        players.Add(id, retStr);
        id++;

        return retStr;
    }
}
