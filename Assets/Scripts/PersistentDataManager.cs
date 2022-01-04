using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{

    private static PersistentDataManager Instance;

    private string _currentName;
    private string _name = "Name";
    private int _highscore = 0;

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
    }
}
