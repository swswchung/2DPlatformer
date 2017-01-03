using UnityEngine;
using System.Collections;
using System;

public class CPlayerMove : CMove, IInputMove {

    Rigidbody2D _rigidbody2d;
    protected Animator _animator;

    public float _maxSpeed;
    public float _jumpPower;

    public bool _isJump = false;
    public bool _isDoubleJump = false;
    public bool _isGround;

    void Awake()
    {
        _characterState = GetComponent<CCharacterState>();
        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update () {
        InputMove();
        InputJump();
	}

    public void InputMove()
    {
        float move = Input.GetAxis("Horizontal");
        if ((_characterState._isRightDir && move < 0) || 
            (!_characterState._isRightDir && 0 < move)) Flip();
        
        Move(move);
    }

    public override void Flip()
    {
        base.Flip();
    }

    public void Move(float move)
    {
        _rigidbody2d.velocity = new Vector2(move * _maxSpeed, _rigidbody2d.velocity.y);

        _animator.SetFloat("Horizontal", move);
        _animator.SetFloat("Vertical", _rigidbody2d.velocity.y);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground" && col.transform.position.y < transform.position.y)
        {
            Grounding(true);
        }
        if (col.gameObject.tag == "Wall" && col.transform.position.y <= transform.position.y)
        {
            Grounding(true);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground"  && col.transform.position.y < transform.position.y)
        {
            _isJump = false;
            _isDoubleJump = false;
            Grounding(true);
        }
        if (col.gameObject.tag == "Wall" && col.transform.position.y <= transform.position.y)
        {
            _isJump = false;
            _isDoubleJump = false;
            Grounding(true);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            _isJump = true;
            Grounding(false);
        }
        if (col.gameObject.tag == "Wall" && col.transform.position.y <= transform.position.y)
        {;
            _isJump = true;
            Grounding(false);
        }
    }

    public void InputJump()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(!_isJump)
            {
                Jump(_jumpPower);

                _isJump = true;
            }
            else if(_isJump && !_isDoubleJump)
            {
                Jump(_jumpPower);

                _isDoubleJump = true;
            }
        }
    }

    public void Jump(float jumpPower)
    {
        _animator.SetTrigger("Jump");

        _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, 0f);
        _rigidbody2d.AddForce(Vector2.up * jumpPower,ForceMode2D.Force);
    }

    public void Grounding(bool isGround)
    {
        _isGround = isGround;

        _animator.SetBool("IsGround", _isGround);
    }  
}