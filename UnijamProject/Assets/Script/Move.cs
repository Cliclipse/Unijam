using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private KeyCode right = KeyCode.D;
    [SerializeField] private KeyCode left = KeyCode.A;
    [SerializeField] private KeyCode jumpButton = KeyCode.W;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 10f;
    [SerializeField] private float maxSpeed = 10f;
    
    [SerializeField] private float slopeCheckDistance;

    private BoxCollider2D _bc2D;
    private Vector2 _colliderSize;
    
    private Rigidbody2D _rigidbody2D;
    private Boolean _isGrounded;
    
    private Animator _animator;
    private int _runHashCode;
    private int _jumpHashCode;
    
    private SpriteRenderer _spriteRenderer;

    void MoveManager()
    {
        if (Input.GetKey(right)) {
            _spriteRenderer.flipX = false;

            if (_rigidbody2D.velocity.x < 0 && _isGrounded) _rigidbody2D.velocity = new Vector2(0, 0);
            if (_rigidbody2D.velocity.x < maxSpeed) _rigidbody2D.velocity += speed * Time.deltaTime * Vector2.right;
        }
        
        else if (Input.GetKey(left))
        {
            _spriteRenderer.flipX = true;

            if (_rigidbody2D.velocity.x > 0 && _isGrounded) _rigidbody2D.velocity = new Vector2(0, 0);
            if (-_rigidbody2D.velocity.x < maxSpeed) _rigidbody2D.velocity += speed * Time.deltaTime * Vector2.left;
            
        }
        else if (_isGrounded)
        {
            _rigidbody2D.velocity = new Vector2(0 , _rigidbody2D.velocity.y);
        }

        if (_rigidbody2D.velocity.magnitude == 0 || !_isGrounded)
        {
            _animator.SetBool(_runHashCode, false);
        }
        else 
        {
            _animator.SetBool(_runHashCode, true);
        }
    }

    void JumpManager()
    {
        if (Input.GetKeyDown(jumpButton) && _isGrounded )
        {
            _isGrounded = false;
            _animator.SetBool(_jumpHashCode, true);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0f);
            _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        _bc2D = GetComponent<BoxCollider2D>();
        _colliderSize = _bc2D.size;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponentInChildren<Animator>();
        
        _spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();

    }

    protected void Awake()
    {
        _runHashCode = Animator.StringToHash("IsWalking");
        _jumpHashCode = Animator.StringToHash("IsJumping");
    }

    private void CheckGround()
    { 

        _isGrounded = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), Vector2.down, 0.3f , LayerMask.GetMask("Platform"));
        if (_isGrounded)
        {
            _animator.SetBool(_jumpHashCode, false);
        }
    }

    /*
    private void CheckSlope()
    {
        Vector2 checkPos = transform.position - new Vector3(0.0f , _colliderSize.y/2);
        CheckSlopeVertical(checkPos);
    }

    private void CheckSlopeHorizontal(Vector2 checkPos)
    {
        
    }
    private void CheckSlopeVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down , slopeCheckDistance , _layer); 
        Debug.Log(hit.point);
        Debug.Log(hit.normal);
        Debug.Log(_layer);
        Debug.DrawRay(hit.point, hit.normal, Color.red);
    }
*/
    
    
    // Update is called once per frame
    void Update()
    {
        CheckGround();
        JumpManager();
        MoveManager();
    }
}
