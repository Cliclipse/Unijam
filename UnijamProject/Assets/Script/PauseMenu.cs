using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseMenu;
    [SerializeField] bool paused;
    void Start()
    {
        paused = true;
        ShowPauseMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPauseMenu();
        }
    }

    // Update is called once per frame
    public void ShowPauseMenu()
    {
        if (!paused)
        {
            pauseMenu.SetActive(true);
            paused = !paused;
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            paused = !paused;
            Time.timeScale = 1;
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("BaitScene");
    }
    
}
