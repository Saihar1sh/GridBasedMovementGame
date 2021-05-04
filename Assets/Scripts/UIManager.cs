using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button pauseBtn, createGridBtn;
    [SerializeField]
    private Image pauseBGImage;
    [SerializeField]
    private Text rows_txt, cols_txt;

    private bool pausePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseBtn.onClick.AddListener(PauseGame);
        createGridBtn.onClick.AddListener(CreateGrid);
        pauseBGImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void PauseGame()
    {
        pausePressed = !pausePressed;
        if (pausePressed)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        pauseBGImage.enabled = pausePressed;
    }
    private void CreateGrid()
    {
        int rows = int.Parse(rows_txt.text);
        int cols = int.Parse(cols_txt.text);
        GridManager.Instance.rows = rows;
        GridManager.Instance.cols = cols;
    }
}
