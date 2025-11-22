using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheckRotate : MonoBehaviour
{   
    [SerializeField] private GameObject obstacle;
    public float forceAmount = 500f;

    void Start()
    {
        Destroy(GetComponent<SpriteRenderer>());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger debrisr fall");
        float halfHeight = transform.localScale.y / 2f;
        
        Vector2 pos = (Vector2)transform.position + new Vector2(0, halfHeight);
        
        Vector2 dir = transform.right * forceAmount;
        
        obstacle.GetComponent<Rigidbody2D>().AddForceAtPosition(dir, pos,ForceMode2D.Force);
    }

}
