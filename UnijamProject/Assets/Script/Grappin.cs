using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class Grappin : MonoBehaviour
{
    [SerializeField] private Camera cameraOfScene;
    [SerializeField] private Hook hook;
    [SerializeField] private float speedDashGrappin = 80f;
    
    public LineRenderer line;

    private float _drag;
    
    public Vector3 hookPosition;
    
    private Vector2 _positionHitCible;
    private Vector2 _direction;
    private Hook _hookInstance;
    
    
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2DPolygon;
    private Collider2D _collider2DBox;

    private float _distCamera;

    private bool _isGrabbing = false;
    private bool _isHooking = false;
    public bool isHooked = false;
    private bool _isRushPrepared = false;
    private bool _onTarget = false;

    


    private void ClicCheck()
    {
        if (Input.GetMouseButton(0))
        { 
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // distance entre la caméra et le plan du jeu
            Vector3 positionClic = cameraOfScene.ScreenToWorldPoint(mousePos);
            
            _isGrabbing = true;
            if (!_isHooking)
            {
                _isHooking = true;
                _hookInstance = Instantiate(hook , transform);
                _hookInstance.transform.localScale *=2 ;
                Debug.Log(positionClic);
                
                Vector2 direction = (positionClic - transform.position ).normalized;
                Debug.Log(direction);
                _hookInstance.direction = direction;
                _hookInstance.player = this;
            }
        }
    }
    
    
    private void _SetRushParam()
    {
        
        _collider2DPolygon.enabled= true;
        _collider2DBox.enabled = false;
        _rigidbody2D.drag = 0;
        
        
        _direction = (hookPosition - transform.position).normalized;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.75f , transform.position.z);
        
        transform.position += Time.deltaTime * speedDashGrappin * new Vector3(_direction.x, _direction.y, 0);
        _rigidbody2D.velocity = _direction.normalized * speedDashGrappin;        
        _isRushPrepared = true;

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
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.drag = _drag;
        
        Destroy(_hookInstance.gameObject);

        
    }
    
    
    void Start()
    {
        Physics.defaultMaxDepenetrationVelocity = 5f;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        
        
        _collider2DBox = GetComponent<PolygonCollider2D>();
        _collider2DPolygon = GetComponent<PolygonCollider2D>();
        
        _collider2DPolygon.enabled= false;
        _collider2DBox.enabled = true;

        _onTarget = false;
        _direction = (hookPosition - transform.position).normalized;
        
        _distCamera = cameraOfScene.transform.position.z;
        _drag = _rigidbody2D.drag;

    }
    void Update()
    {
        if (!_isGrabbing) ClicCheck();
        else if (!_isRushPrepared && isHooked) _SetRushParam();
        
        if (_hookInstance != null)
        {
            line.enabled = true;
            line.positionCount = 2; // début + fin
            line.SetPosition(0, transform.position);
            line.SetPosition(1, _hookInstance.gameObject.transform.position);
        }
        else
        {
            line.enabled = false;
        }
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


