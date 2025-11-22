using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheckDebris : MonoBehaviour
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
            Debug.Log("trigger debris fall");
            obstacle.GetComponent<FallingObstacle>().startFalling();
        }
        

    }
}
