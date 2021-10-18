using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScore;
    private void Awake()
    {
        highScore.text = "High Score " + PlayerPrefs.GetInt("HighScore").ToString();
    }
    
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
