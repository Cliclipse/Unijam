using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseMenu;
    [SerializeField] public bool paused; 
    public static PauseMenu Instance;
    [SerializeField] public KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] public KeyCode jumpKey ;
    [SerializeField] private TMP_Text jumpText;
    [SerializeField] public KeyCode leftKey ;
    [SerializeField] public KeyCode rightKey;
    [SerializeField] private bool listeningJump;
    [SerializeField] private bool listeningLeft;
    [SerializeField] private bool listeningRight;
    [SerializeField] private GameObject whiteScreen;
    [SerializeField] private GameObject pauseCanva;
 
    void Awake()
    {
        
        if(Instance != null && Instance!=this) Destroy(pauseCanva);
        Instance = this;
    }
    void Start()
    {
        paused = true;
        ShowPauseMenu();
        // DontDestroyOnLoad(pauseCanva);
        // SetButton();
        whiteScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            ShowPauseMenu();
            listeningJump = false;
            listeningLeft = false;
            listeningRight = false;
        }
        
    }

    /*
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && listeningJump == true && e.keyCode != pauseKey)
        {
            jumpKey = e.keyCode;
            jumpText.text ="Boutton de Saut: "+ jumpKey.ToString();
            UpdateButton();
        }
        else if (e.isKey && listeningLeft == true && e.keyCode != pauseKey)
        {
            leftKey = e.keyCode;
            jumpText.text ="Boutton de Saut: " + leftKey.ToString();
            UpdateButton();
        }
        else if (e.isKey && listeningRight == true && e.keyCode != pauseKey)
        {
            rightKey = e.keyCode;
            jumpText.text ="Boutton de Saut: " + rightKey.ToString();
            UpdateButton();
        }
        if(e.isKey)
        {
            whiteScreen.SetActive(false);
        }
    }*/

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
        SceneManager.LoadScene("MainScreen");
    }

   /* public void SetButton()
    {
        jumpKey = Move.Instance.jumpButton;
        leftKey = Move.Instance.left;
        rightKey = Move.Instance.right;
    }

    public void ListenToRightButton()
    {
        listeningRight = true;
    }

    public void ListenToJumpButton()
    {
        listeningJump = true;
        whiteScreen.SetActive(true);
    }public void ListenToLeftButton()
    {
        listeningLeft = true;
    }

    public void UpdateButton()
    {
        Move.Instance.jumpButton = jumpKey;
        Move.Instance.left = leftKey;
        Move.Instance.right = rightKey;
    }*/
}
