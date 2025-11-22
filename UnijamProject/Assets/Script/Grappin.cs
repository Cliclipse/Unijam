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

    
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    private bool _isGrabbing = false;
    private bool _isHooking = false;
    public bool _isHooked = false;
    private bool _isRushPrepared = false;
    private bool _onTarget = false;

    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<BoxCollider2D>();

        _onTarget = false;
        _direction = (hookPosition - transform.position).normalized;
    }

    private void ClicCheck()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector2 position = cameraOfScene.ScreenToWorldPoint(mousePosition);
        Collider2D detectedCollider = Physics2D.OverlapPoint(position, LayerMask.GetMask("Cible"));

        if (detectedCollider != null && Input.GetMouseButton(0))
        {
            _positionHitCible = detectedCollider.gameObject.transform.position;
            _isGrabbing = true;
        }

    }

    private void Hook()
    {
        if (!_isHooking)
        {
            _isHooking = true;
            Hook hookInstance = Instantiate(hook , transform.position , Quaternion.identity);
            hookInstance.target = _positionHitCible;
            hookInstance.player = this;
        }
    }
    
    private void _SetRushParam()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _direction = (hookPosition - transform.position).normalized;
        _isRushPrepared = true;
    }


    private void SnkSimulation()
    {
        Vector3 delta = speedDashGrappin * Time.deltaTime * _direction;
        if (Vector2.Distance(transform.position, hookPosition) < delta.magnitude)
        {
            transform.position = hookPosition;
            _onTarget = true; 
            _collider2D.enabled = false; 
            
        }
        else
        {
            transform.position += delta;
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic; 
        }
        
    }

    private void SpiderManSimulation()
    {
        Debug.Log("Spider Man");
        if (!Input.GetMouseButton(0))
        {
            
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(_onTarget);
        if (!_isGrabbing) ClicCheck();
        else if (!_isHooked) Hook();
        else if (!_isRushPrepared && _isHooked) _SetRushParam();
        else if (!_onTarget) SnkSimulation();
        
    }
}