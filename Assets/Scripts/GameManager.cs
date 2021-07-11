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
        //���̺� ����
        string dirPath;
        dirPath = Application.dataPath + "/save";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        string source = "";
        //�÷��̾� ���� (�����ؾ���)
        players = new Dictionary<int, string>();
        int id = 1;
        for(int i = 0; i < 100; i++)
        {
            source += MakeRandomPlayer(ref id, ref players);
        }
        //TODO: �� ����

        //�ӽ� �� ���� ���� �ۼ� 
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
        //���� id number
        StringBuilder ret = new StringBuilder(id.ToString());
        ret.Append(" ");
        //TODO: ���� �̸�
        ret.Append("��");
        ret.Append(" ");
        ret.Append("ö��");
        ret.Append(" ");
        //TODO: ����. 1�������� 1~4 ���� ����, 1���������� ���� ���� ������ �ٸ����ؼ� �� ����
        ret.Append(UnityEngine.Random.Range(3,8) + " "); //��
        ret.Append(UnityEngine.Random.Range(3, 8) + " "); //��
        ret.Append(UnityEngine.Random.Range(3, 8) + " "); //ü

        ret.Append("\n");
        string retStr = ret.ToString();
        //���� ��Ͽ� �߰�
        players.Add(id, retStr);
        id++;

        return retStr;
    }
}
