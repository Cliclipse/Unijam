using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCutscene : MonoBehaviour
{
    void OnEnable() 
    {
        SceneManager.LoadScene("PaquitoScene", LoadSceneMode.Single);
    }
}
