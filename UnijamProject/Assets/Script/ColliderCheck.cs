using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{   
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
            obstacle.GetComponent<Rigidbody2D>().gravityScale=1;
            obstacle.GetComponent<FallingObstacle>().setFalling(true);
        }
        

    }
}
