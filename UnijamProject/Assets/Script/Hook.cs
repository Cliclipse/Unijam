using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private float speed = 90f;
    [SerializeField] private float maxRange = 20f;
    [SerializeField] private float minRange = 0.25f;


    public Grappin player;
    public Vector2 direction;
    private bool _onTarget = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(direction);
        _onTarget = false;
    }

    void FixHook(Vector2 contactPoint)
    {
        transform.position = contactPoint; ;
        _onTarget = true;
        player.isHooked = true;
        player.hookPosition = transform.position ;
    }
    
    //S'optimise en faisant pas la distance pour épargner la rac carrée
    private void Rush()
    {
        Vector3 delta = speed * Time.deltaTime * direction;
            transform.position += delta;
    }

    // Update is called once per frame
    void Update() 
    {
        if (!_onTarget) Rush();
        if ((transform.position - player.transform.position).magnitude > maxRange)
        {
            Destroy(gameObject);
            player.Reset();       // En vrai faudrait plutôt que ce soit le grappin qui check la distance du hook et reset

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((player.transform.position - transform.position).magnitude > minRange)
        {
            Debug.Log("test");
            FixHook(collision.GetContact(0).point);
        }
        else
        {
            Debug.Log("test2");
            Destroy(gameObject);
            player.Reset();

        }
    }
}
