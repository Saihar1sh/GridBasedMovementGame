﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button pauseBtn, startMenuBtn, exitBtn;
    [SerializeField]
    private Image pauseBGImage;
    [SerializeField]
    private PlayerMovement player;

    private bool pausePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1;
        pauseBtn.onClick.AddListener(PauseGame);
        startMenuBtn.onClick.AddListener(LoadStartMenu);
        exitBtn.onClick.AddListener(ExitGame);
        pauseBGImage.gameObject.SetActive(false);
    }

    private void PauseGame()
    {
        pausePressed = !pausePressed;
        if (pausePressed)
        {
            //Time.timeScale = 0;
            player.DisableMovement();
        }
        else
        {
            //Time.timeScale = 1;
            player.EnableMovement();
        }
        pauseBGImage.gameObject.SetActive(pausePressed);
    }
    private void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
