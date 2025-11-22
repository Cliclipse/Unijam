using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappin : MonoBehaviour
{
    [SerializeField] private LayerMask cibleMaskLayer;
    [SerializeField] private Camera cameraOfScene;
    [SerializeField] private Hook hook;
    
    private Vector2 _positionHitCible;
    
    private bool _isGrabbing = false;
    private bool _isHooked = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void ClicCheck()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector2 position = cameraOfScene.ScreenToWorldPoint(mousePosition);

        Collider2D detectedCollider = Physics2D.OverlapPoint(position, cibleMaskLayer);

        if (detectedCollider != null)
        {
            _positionHitCible = detectedCollider.gameObject.transform.position;
            _isGrabbing = true;
        }

    }

    private void Hook()
    {
        Hook hookInstance = Instantiate(hook , transform.position , Quaternion.identity);
        hookInstance.target = _positionHitCible;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_isGrabbing) ClicCheck();
        else if (!_isHooked) Hook();
        
    }
}