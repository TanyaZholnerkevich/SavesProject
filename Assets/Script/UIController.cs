using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text heathText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text levelText;
    
    [SerializeField] private GameObject endPanel;

    [SerializeField] private PlayerController playerController;
    private void OnEnable()
    {
        PlayerController.OnGameOver += PlayerControllerOnOnGameOver;
    }
    private void OnDisable()
    {
        PlayerController.OnGameOver -= PlayerControllerOnOnGameOver;
    }
    private void PlayerControllerOnOnGameOver()
    {
        endPanel.SetActive(true);
    }
    private void Start()
    {
        endPanel.SetActive(false);
    }
    private void Update()
    {
        SetTextValues();
    }
    private void SetTextValues()
    {
        heathText.text = playerController.health.ToString();
        coinsText.text = playerController.coins.ToString();
        levelText.text = playerController.level.ToString();
    }
    public void RestartGame()
    {
        endPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
