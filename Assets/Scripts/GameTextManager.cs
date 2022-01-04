using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTextManager : MonoBehaviour
{
    [SerializeField]
    private Text _highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHighScoreText()
    {
        _highscoreText.text = "Highscore: " + PersistentDataManager.getInstance().Name + " - " + PersistentDataManager.getInstance().HighScore;
    }
}
