using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheckSpike : MonoBehaviour
{
    //kills player when entering hitbox
    void Start()
    {
        Destroy(GetComponent<SpriteRenderer>());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Mort");
        }
        

    }

}
