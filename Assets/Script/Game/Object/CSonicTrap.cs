using UnityEngine;
using System.Collections;

public class CSonicTrap : CMove {

    Rigidbody2D _rigidbody2d;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    public GameObject _shotGun;
    bool _isCol;
    
    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

	void Start()
    {
        _rigidbody2d.velocity = new Vector2(-50f, 0f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            col.collider.SendMessage("Damage", -1f);
            _rigidbody2d.velocity = Vector2.zero;
        }

        else if(col.gameObject.tag.Equals("Wall") && !_isCol)
        {
            _animator.SetTrigger("ColWall");
            _isCol = true;
            _rigidbody2d.velocity = Vector2.zero;
            _rigidbody2d.AddForce(new Vector2(100f, 350f));
        }
        else if(_isCol && col.gameObject.tag.Equals("Ground"))
        {
            _isCol = false;
            _animator.SetTrigger("IsGround");
            _rigidbody2d.velocity = Vector2.zero;
        }
    }

    public void SonicReturnAnimation()
    {
        Instantiate(_shotGun, transform.position, Quaternion.identity);
        _spriteRenderer.flipX = true;
        _rigidbody2d.velocity = new Vector2(100f, 0f);
        Invoke("DestroyTrap", 1f);
    }

    void DestroyTrap()
    {
        Destroy(gameObject);
    }
}
