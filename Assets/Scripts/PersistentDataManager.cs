using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistentDataManager : MonoBehaviour
{

    private static PersistentDataManager Instance;

    private string _currentName;
    private string _name = "Name";
    private int _highscore = 0;
    private string _path;

    public string CurrentName
    {
        get => _currentName;
        set => _currentName = value;
    }
    public string Name
    {
        get => _name;
    }

    public int HighScore
    {
        get => _highscore;
    }

    public bool SetScore(string name, int highscore)
    {
        if(highscore > _highscore)
        {
            _highscore = highscore;
            _name = name;
            SaveScore();
            return true;        }
        return false;
    }

    public static PersistentDataManager getInstance()
    {
        return Instance;
    }


    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        } else
        {
            _path = Application.persistentDataPath + "/safefile.json";
            LoadFromFile(_path);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Name = _name;
        data.Score = _highscore;
        SaveToFile(data);
    }

    private void SaveToFile(SaveData data)
    {
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(_path, json);
    }

    private void LoadFromFile(string path)
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            _highscore = data.Score;
            _name=data.Name;
        }
    }
    
}
