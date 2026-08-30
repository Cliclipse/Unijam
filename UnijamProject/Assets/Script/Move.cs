using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{

    [SerializeField] public KeyCode right = KeyCode.D;
    [SerializeField] public KeyCode left = KeyCode.A;
    [SerializeField] public KeyCode jumpButton = KeyCode.W;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 10f;
    [SerializeField] private float maxSpeed = 10f;
    
    [SerializeField] private float slopeCheckDistance;

    private BoxCollider2D _bc2D;
    
    private Rigidbody2D _rigidbody2D;
    private Boolean _isGrounded;
    
    private Animator _animator;
    private int _runHashCode;
    private int _jumpHashCode;
    
    private SpriteRenderer _spriteRenderer;
    public static Move Instance;


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
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponentInChildren<Animator>();
        
        _spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        /*if (SceneManager.GetActiveScene().name != "nv1_L")
        {
            Debug.Log("Change !");
            PauseMenu.Instance.UpdateButton();
        }
        else
        {
            PauseMenu.Instance.SetButton();
        }*/
    }

    protected void Awake()
    {
        _runHashCode = Animator.StringToHash("IsWalking");
        _jumpHashCode = Animator.StringToHash("IsJumping");
        Instance = this;
    }

    private void CheckGround()
    { 
        _isGrounded = (Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), Vector2.down, 0.2f , LayerMask.GetMask("Platform")) || Physics2D.Raycast(new Vector2(transform.position.x+0.1f, transform.position.y - 0.5f), Vector2.down, 0.2f , LayerMask.GetMask("Platform")) || Physics2D.Raycast(new Vector2(transform.position.x -0.1f, transform.position.y - 0.5f), Vector2.down, 0.2f , LayerMask.GetMask("Platform"))) ;
        _animator.SetBool(_jumpHashCode, !_isGrounded);
    }

    void Update()
    {
        if (!PauseMenu.Instance.paused)
        {
            CheckGround();
            JumpManager();
            MoveManager();
        }
    }
}
