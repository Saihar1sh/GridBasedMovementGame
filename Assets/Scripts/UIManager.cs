using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button pauseBtn;
    [SerializeField]
    private Image pauseBGImage;

    private bool pausePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseBtn.onClick.AddListener(PauseGame);
        pauseBGImage.enabled = false;
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
}
