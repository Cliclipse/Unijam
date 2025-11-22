using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    private bool isFalling = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFalling(bool newState)
    {
        this.isFalling=newState;
    }

    public void startFalling()
    {
        GetComponent<Rigidbody2D>().gravityScale=1;
        this.setFalling(true);
    }


    void OnCollisionEnter2D(Collision2D other)
    {  
        if (other.gameObject.CompareTag("Player"))
        {
            if (isFalling)
            {
                Debug.Log("mort");
            }
        }
        else 
        {
            this.setFalling(false);
        }
    }

}
