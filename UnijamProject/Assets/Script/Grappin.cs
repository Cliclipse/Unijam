using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappin : MonoBehaviour
{
    [SerializeField] private Camera cameraOfScene;
    [SerializeField] private Hook hook;
    [SerializeField] private float speedDashGrappin = 50f;
    
    public Vector3 hookPosition;
    
    private Vector2 _positionHitCible;
    private Vector2 _direction;
    private Hook _hookInstance;
    
    
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2DPolygon;
    private Collider2D _collider2DBox;


    private bool _isGrabbing = false;
    private bool _isHooking = false;
    public bool isHooked = false;
    private bool _isRushPrepared = false;
    private bool _onTarget = false;

    


    private void ClicCheck()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector2 position = cameraOfScene.ScreenToWorldPoint(mousePosition);
        if (Input.GetMouseButton(0))
        {
            _isGrabbing = true;
            if (!_isHooking)
            {
                _isHooking = true;
                _hookInstance = Instantiate(hook , transform.position , Quaternion.identity);
                Debug.Log(_hookInstance);
                _hookInstance.direction = (position - new Vector2(transform.position.x, transform.position.y) ).normalized;
                _hookInstance.player = this;
            }
        }
    }
    
    
    private void _SetRushParam()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _isRushPrepared = true;
        
        _collider2DPolygon.enabled= true;
        _collider2DBox.enabled = false;
        
        //_rigidbody2D.velocity = _direction * speedDashGrappin;
        
        
    }
    


    private void SnkSimulation()
    {
        _direction = (hookPosition - transform.position).normalized;
        Vector3 delta = speedDashGrappin * Time.deltaTime * _direction;
        if ((transform.position - hookPosition).magnitude < delta.magnitude)
        {
            transform.position = hookPosition;
            _onTarget = true; 
            Reset();
        }
        else
        {
            transform.position += delta;
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic; 
        }
    }
    



    public void Reset()
    {
        _isGrabbing = false;
        _isHooking = false;
        isHooked = false;
        _isRushPrepared = false;
        _onTarget = false;
        
        _collider2DPolygon.enabled= false;
        _collider2DBox.enabled = true;
        
        Destroy(_hookInstance);

        
    }
    
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        _collider2DBox = GetComponent<PolygonCollider2D>();
        _collider2DPolygon = GetComponent<PolygonCollider2D>();
        
        _collider2DPolygon.enabled= false;
        _collider2DBox.enabled = true;

        _onTarget = false;
        _direction = (hookPosition - transform.position).normalized;
    }
    void Update()
    {
        if (!_isGrabbing) ClicCheck();
        else if (!_isRushPrepared && isHooked) _SetRushParam();
        else if (!_onTarget && isHooked) SnkSimulation();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isHooked)
        {
            Reset();
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic; 
        }
    }
}