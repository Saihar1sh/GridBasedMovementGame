using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private Button playBtn, exitBtn;
    [SerializeField]
    private TMP_InputField rows_txt, cols_txt, speed_txt;

    private void Awake()
    {
        playBtn.onClick.AddListener(PlayGame);
        exitBtn.onClick.AddListener(ExitGame);
    }

    private void PlayGame()
    {
        SetInputValues();
        SceneManager.LoadScene(1);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void SetInputValues()
    {
        if (int.Parse(rows_txt.text) < 0 || int.Parse(cols_txt.text) < 0)
            return;
        PlayerPrefs.SetInt("InputRows", int.Parse(rows_txt.text));
        PlayerPrefs.SetInt("InputCols", int.Parse(cols_txt.text));
        PlayerPrefs.SetInt("InputSpeed", int.Parse(speed_txt.text));
    }

}