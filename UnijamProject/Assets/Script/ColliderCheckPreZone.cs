using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheckPreZone : MonoBehaviour
{   
    //intiates fall of obstacle object when entering hitbox
    [SerializeField] private GameObject obstacle;

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
                Debug.Log("start music brbrbrbrbr");
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("stop music brbrbrbrbr");
        }
    }
}
