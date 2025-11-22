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
        Debug.Log("trigger eboulement");
        obstacle.GetComponent<Rigidbody2D>().gravityScale=1;
    }
}
