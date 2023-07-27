using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string BestName;
    public int BestScore;
    public string CurrName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadValue();
    }

    public void SaveValue()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        // ������� ������ ��� ����������
        SaveData data = new SaveData();
        // ��������� �� ������� ��������
        data.BestName = BestName;
        data.BestScore = BestScore;
        // �������������� � JSON ����
        string json = JsonUtility.ToJson(data);
        // ��������� ���� �� ����
        File.WriteAllText(path, json);
    }

    public void LoadValue()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestName = data.BestName;
            BestScore = data.BestScore;
        }
    }



    [SerializeField]
    public class SaveData
    {
        public string BestName;
        public int BestScore;
    }


}
