using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathManager :MonoBehaviour
{
       [SerializeField] private GameObject DeathMenu;
       [SerializeField] private GameObject EndScreen;
       [SerializeField] private AudioSource deathSound;
       public static DeathManager Instance;


       private void Start()
       {
              Instance = this;
              SetScene();

       }

       public void SetScene()
       {
              StartCoroutine(UnfadeCoroutine(false));
       }
       public void ResetScene(bool end)
       {
              StartCoroutine(FadeCoroutine(end));
       }

       IEnumerator FadeCoroutine(bool end=false)
       {
              DeathMenu.SetActive(true);
              for (int i = 0; i < 100; i++)
              {
                     Color fadecolor = new Color(0, 0, 0, Mathf.Lerp(0, 1, i/10000.0f)*255f);
                     DeathMenu.GetComponent<Image>().color = fadecolor;
                     yield return new WaitForEndOfFrame();
              }

              if (end == false)
              {
                     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                     deathSound.Play();
              }
              else
              {
                     DeathMenu.SetActive(false);
                     StartCoroutine(UnfadeCoroutine(true));
              }
       }

       IEnumerator UnfadeCoroutine(bool end)
       {
              
              DeathMenu.SetActive(true);
              if (end == true)
              {
                     EndScreen.gameObject.SetActive(true);
                     
              }
              else
              {
                     Color fadecolor = new Color(0, 0, 0, 255f);
                     DeathMenu.GetComponent<Image>().color = fadecolor;
                     //yield return new WaitForSeconds(1f);
                     for (int i = 0; i < 100; i++)
                     {
                            fadecolor = new Color(0, 0, 0, (Mathf.Lerp(0, 1, (100-i)/10000.0f)*255f));
                            DeathMenu.GetComponent<Image>().color = fadecolor;
                            yield return new WaitForEndOfFrame();
                     }    
              }
              
              DeathMenu.SetActive((false));
              
       }
}
