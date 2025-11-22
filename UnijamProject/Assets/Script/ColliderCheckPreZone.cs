using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheckPreZone : MonoBehaviour
{
    //intiates fall of obstacle object when entering hitbox
    [SerializeField] private GameObject obstacle;
    [SerializeField]  private AudioSource audioSourcefall;
    

    void Start()
    {
        Destroy(GetComponent<SpriteRenderer>());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (!obstacle.GetComponent<FallingObstacle>().getDidFall())
            {
               audioSourcefall.Play(); ;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {        
        if (other.gameObject.CompareTag("Player"))
        {
            audioSourcefall.Stop();
        }
    }
}
