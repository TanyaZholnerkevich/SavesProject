using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;

    public static int currentLevel;
    public static bool isLoad = false;
    public void StartLevel1()
    {
        startPanel.SetActive(false);
        SceneManager.LoadScene(1);
        currentLevel = 1;
        isLoad = false;
    }
    public void StartLevel2()
    {
        startPanel.SetActive(false);
        SceneManager.LoadScene(2);
        currentLevel = 2;
        isLoad = false;
    }
    public void StartLevel3()
    {
        startPanel.SetActive(false);
        SceneManager.LoadScene(3);
        currentLevel = 3;
        isLoad = false;
    }
    public void LoadSavedLevel()
    {
        PlayerData data = Saving.LoadPlayerData();
        currentLevel = data.level;
        isLoad = true;
        SceneManager.LoadScene(currentLevel);
    }
}
