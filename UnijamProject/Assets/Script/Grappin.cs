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
        Collider2D detectedCollider = Physics2D.OverlapPoint(position, LayerMask.GetMask("Platform") );
        
        if (detectedCollider != null && Input.GetMouseButton(0))
        {
            _positionHitCible = detectedCollider.gameObject.transform.position;
            _isGrabbing = true;
            if (!_isHooking)
            {
                _isHooking = true;
                _hookInstance = Instantiate(hook , transform.position , Quaternion.identity);
                _hookInstance.target = new Vector3(position.x, position.y);
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
        
        
    }


    private void SnkSimulation()
    {
        _direction = (hookPosition - transform.position).normalized;
        Vector3 delta = speedDashGrappin * Time.deltaTime * _direction;
        if ((transform.position - hookPosition).magnitude < delta.magnitude)
        {
            transform.position = hookPosition;
            _onTarget = true; 
            Destroy(_hookInstance);
            ResetBools();
        }
        else
        {
            transform.position += delta;
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic; 
        }
    }


    private void ResetBools()
    {
        _isGrabbing = false;
        _isHooking = false;
        isHooked = false;
        _isRushPrepared = false;
        _onTarget = false;
        
        _collider2DPolygon.enabled= false;
        _collider2DBox.enabled = true;
        
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
            ResetBools();
            Destroy(_hookInstance);
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic; 
        }
    }
}