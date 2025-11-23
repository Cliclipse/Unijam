using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathManager :MonoBehaviour
{
       [SerializeField] private GameObject DeathMenu;
       [SerializeField] private AudioSource deathSound;
       public static DeathManager Instance;


       private void Start()
       {
              Instance = this;
              SetScene();

       }

       public void SetScene()
       {
              StartCoroutine(UnfadeCoroutine());
       }
       public void ResetScene()
       {
              StartCoroutine(FadeCoroutine());
       }

       IEnumerator FadeCoroutine()
       {
              DeathMenu.SetActive(true);
              for (int i = 0; i < 100; i++)
              {
                     Color fadecolor = new Color(0, 0, 0, Mathf.Lerp(0, 1, i/10000.0f)*255f);
                     DeathMenu.GetComponent<Image>().color = fadecolor;
                     yield return new WaitForEndOfFrame();
              }
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
              deathSound.Play();
       }

       IEnumerator UnfadeCoroutine()
       {
              
              DeathMenu.SetActive(true);
              Color fadecolor = new Color(0, 0, 0, 255f);
              DeathMenu.GetComponent<Image>().color = fadecolor;
              yield return new WaitForSeconds(1f);
              for (int i = 0; i < 100; i++)
              {
                     fadecolor = new Color(0, 0, 0, (Mathf.Lerp(0, 1, (100-i)/10000.0f)*255f));
                     DeathMenu.GetComponent<Image>().color = fadecolor;
                     yield return new WaitForEndOfFrame();
              } 
              DeathMenu.SetActive((false));
              
       }
}
