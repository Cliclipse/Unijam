using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private float speed = 90f;


    public Grappin player;
    public Vector2 target;
    private Vector2 _direction;
    private bool _onTarget = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _onTarget = false;
        _direction = (target - new Vector2(transform.position.x, transform.position.y) ).normalized;
    }

    void FixHook()
    {
        transform.position = target;
        _onTarget = true;
        player.isHooked = true;
        player.hookPosition = transform.position ;
    }
    
    //S'optimise en faisant pas la distance pour épargner la rac carrée
    private void Rush()
    {
        Vector3 delta = speed * Time.deltaTime * _direction;
        if (Vector2.Distance(transform.position, target) < delta.magnitude)
        {
            FixHook();
        }
        else
        {
            transform.position += delta;
        }
    }

    // Update is called once per frame
    void Update() 
    {
        if (!_onTarget) Rush();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        FixHook();
    }
}
