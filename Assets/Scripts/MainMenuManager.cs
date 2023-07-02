using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private AssetBundle _assetBundle;
    [SerializeField] private Button _exitButton;
    // Start is called before the first frame update
    void Start()
    {
        _playButton.onClick.AddListener(Play); 
        _exitButton.onClick.AddListener(Exit);
    }

    void Play() {
        SceneManager.LoadScene(1);
    }

    void Exit() {
        Application.Quit();
    }

}
