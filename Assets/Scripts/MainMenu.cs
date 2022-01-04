using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private InputField _inputField;
    [SerializeField]
    private Text _highscoreText;

    public void Start()
    {
        _highscoreText.text = "Highscore: " + PersistentDataManager.getInstance().Name + " - " + PersistentDataManager.getInstance().HighScore;
    }

    public void OnStart()
    {
        PersistentDataManager.getInstance().CurrentName = _inputField.text;
        SceneManager.LoadScene(1);
        
    }

    public void OnQuit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }
}
