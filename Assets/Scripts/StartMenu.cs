using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private Button playBtn, exitBtn;
    [SerializeField]
    private TextMeshProUGUI rows_txt, cols_txt;

    private void Awake()
    {
        playBtn.onClick.AddListener(PlayGame);
        exitBtn.onClick.AddListener(ExitGame);
    }

    private void PlayGame()
    {
        //SetGridValues();
        SceneManager.LoadScene(1);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void SetGridValues()
    {
        int rows = int.Parse(rows_txt.text);
        int cols = int.Parse(cols_txt.text);
        GridManager.Instance.rows = rows;
        GridManager.Instance.cols = cols;
    }

}