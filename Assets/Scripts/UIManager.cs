using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button pauseBtn, startMenuBtn, exitBtn;
    [SerializeField]
    private Image pauseBGImage;

    private bool pausePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseBtn.onClick.AddListener(PauseGame);
        startMenuBtn.onClick.AddListener(LoadStartMenu);
        exitBtn.onClick.AddListener(ExitGame);
        pauseBGImage.gameObject.SetActive(false);
    }

    private void PauseGame()
    {
        pausePressed = !pausePressed;
        if (pausePressed)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
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
