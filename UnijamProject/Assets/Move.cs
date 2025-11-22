using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private KeyCode right = KeyCode.D;
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode jumpButton = KeyCode.W;


    
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    
    Rigidbody2D rigidbody2D;

    void MoveManager()
    {
        if (Input.GetKey(right)) transform.position += speed * Time.deltaTime * Vector3.right; 
        if (Input.GetKey(left)) transform.position += speed * Time.deltaTime * Vector3.left; 
    }

    void JumpManager()
    {
        if (Input.GetKeyDown(jumpButton))
        {
            Boolean hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), Vector2.down  , 0.1f , LayerMask.GetMask("Platform"));
            Debug.Log(hit);
            rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveManager();
        JumpManager();
    }
}
