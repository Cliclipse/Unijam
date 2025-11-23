using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject CreditsMenu;
    // Start is called before the first frame update
    void Awake()
    {
            ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playnow()
    {
        SceneManager.LoadScene("IntroCutscene");
    }
    public void ShowSettings()
    {
        mainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
