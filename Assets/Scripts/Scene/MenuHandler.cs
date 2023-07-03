using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitGameButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitGameOverButton;
    [SerializeField] private Button _restartGameOverButton;
    [SerializeField] private GameObject _playersControlUI; 
    [SerializeField] private GameObject _pauseUI; 
    [SerializeField] private GameObject _gameOverUI; 
    internal static MenuHandler Instance;

    private void Awake() {
        Instance = this;
        _pauseButton.onClick.AddListener(Pause);
        _continueButton.onClick.AddListener(Continue);
        _exitGameButton.onClick.AddListener(Exit);
        _restartButton.onClick.AddListener(Restart);
        _restartGameOverButton.onClick.AddListener(Restart);
        _exitGameOverButton.onClick.AddListener(Exit);
    }

    void Update() {
    }

    void Pause() {
        Time.timeScale = 0;

        _playersControlUI.SetActive(false); 
        _pauseUI.SetActive(true);
    }

    void Continue() {
        Time.timeScale = 1;

        _playersControlUI.SetActive(true); 
        _pauseUI.SetActive(false);
    }

    void Restart() {
        Time.timeScale = 1;

        _gameOverUI.SetActive(false);
        SceneManager.LoadScene(2);
    }

    void Exit() {
        Application.Quit();
    }

    internal void GameOver() {
        Time.timeScale = 0;
    
        _gameOverUI.SetActive(true);
    }
}
