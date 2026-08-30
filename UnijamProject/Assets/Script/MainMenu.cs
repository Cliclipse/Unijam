using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using File = System.IO.File;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject CreditsMenu;
    [SerializeField] private DataToCollect data;
    [SerializeField] private TMP_Text animText;

    private bool first = true;
    // Start is called before the first frame update
    void Awake()
    {
            ShowMainMenu();
            ReadData();
            //WriteData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WriteData()
    {
        string json=JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/DataToCollect.json", json);
    }

    private void ReadData()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/DataToCollect.json");
        JsonUtility.FromJsonOverwrite(json, data);
        first = data.first;
    }
    private void SaveFirst()
    {
        first = false;
        WriteData();
    }
    public void Playnow()
    {
        if (first)
        {
            SaveFirst();
            SceneManager.LoadScene("IntroCutscene");
            
        }
        else
        {
            SceneManager.LoadScene("nv1_L");
        }
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
