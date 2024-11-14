using UnityEngine;
using UnityEngine.SceneManagement;
using System; 

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private GameObject gachaPanel;
    public string levelToLoad;

    public GameObject settingsWindows;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindows.SetActive(true);
        gachaPanel.SetActive(false);
        scorePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("quit");
        settingsWindows.SetActive(false);
        scorePanel.SetActive(false);
        gachaPanel.SetActive(false);

    }

    public void ScoreButton()
    {
        scorePanel.SetActive(true); 
        settingsWindows.SetActive(false);
        gachaPanel.SetActive(false);
    }

    public void GachaButton()
    {
        gachaPanel.SetActive(true);
        settingsWindows.SetActive(false);
        scorePanel.SetActive(false);
    }
}
