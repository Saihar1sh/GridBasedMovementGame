using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private Button playBtn, exitBtn;
    [SerializeField]
    private TMP_InputField rows_txt, cols_txt;

    private int rows, cols;

    private void Awake()
    {
        playBtn.onClick.AddListener(PlayGame);
        exitBtn.onClick.AddListener(ExitGame);
    }

    private void PlayGame()
    {
        SetGridValues();
        SceneManager.LoadScene(1);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void SetGridValues()
    {
        if (int.Parse(rows_txt.text) < 0 || int.Parse(cols_txt.text) < 0)
            return;
        else if (int.Parse(rows_txt.text) + int.Parse(cols_txt.text) <= 80)
        {
            PlayerPrefs.SetInt("InputRows", int.Parse(rows_txt.text));
            PlayerPrefs.SetInt("InputCols", int.Parse(cols_txt.text));

        }
    }

}