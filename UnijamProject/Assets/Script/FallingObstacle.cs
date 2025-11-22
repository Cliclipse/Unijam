using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    [SerializeField] private bool fallInfinite;

    [SerializeField] private bool fallAtStart;

    [SerializeField] private bool notDeadly;
    private bool isFalling = false;
    private Vector3 originPos;
    private Quaternion originRotation;

    private bool didFall = false;

    // Start is called before the first frame update
    void Start()
    {
        if (this.fallAtStart)
        {
            this.startFalling();
        }
        else
        {
            this.GetComponent<Rigidbody2D>().gravityScale=0;
            this.stopFalling();
        }

        this.originPos=GetComponent<Transform>().position;
        this.originRotation=GetComponent<Transform>().rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setFalling(bool newState)
    {
        if (newState)
        {
            this.didFall=true;
        }
        this.isFalling=newState;
    }

    public bool getDidFall()
    {
        return this.didFall;
    }

    public void startFalling()
    {
        Debug.Log("Stop music brbrbrbr");
        this.GetComponent<Rigidbody2D>().gravityScale=1;
        this.setFalling(true);
    }

    private void stopFalling()
    {
        //GetComponent<Rigidbody2D>().gravityScale=0;
        this.setFalling(false);
    }

    private void TPOrigin()
    {
        Debug.Log("TP");
        
        this.GetComponent<Transform>().position=this.originPos;
        this.GetComponent<Transform>().rotation=this.originRotation;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;

    }



    void OnCollisionEnter2D(Collision2D other)
    {  
        if (other.gameObject.CompareTag("Player"))
        {
            if (isFalling && !notDeadly)
            {
                Debug.Log("mort");
            }
        }
        else 
        {   
            Debug.Log("Start music BOOM");
            if (!fallInfinite){
                this.stopFalling();
            }
            else
            {
                this.TPOrigin();
            }
            
        }
    }

}
