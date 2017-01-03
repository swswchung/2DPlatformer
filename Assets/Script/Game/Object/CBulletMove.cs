using UnityEngine;
using System.Collections;

public class CBulletMove : CBulletDamage {

    //CShotGun에서 공격발생시 총알오브젝트 생성, 생성하면서 Player의 isRightDir참조
    //
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    Rigidbody2D _rigidbody2d;
    GameObject _player;
    CircleCollider2D _circleCollider2d;

    public int _damage;
    public float _speed;

    void Awake()
    {
        _circleCollider2d = GetComponent<CircleCollider2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player");
    }

    void OnEnable()
    {
        StopCoroutine("BulletDestroyCoroutine");
        _circleCollider2d.enabled = true;
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        float _movedir = (_player.GetComponent<CCharacterState>()._isRightDir) ? 1 : -1;
        Vector3 theScale = transform.localScale;
        theScale.x = (_movedir < 0) ? -1 : 1;
        transform.localScale = theScale;

        _rigidbody2d.velocity = new Vector2(_movedir * _speed, _rigidbody2d.velocity.y);
        Invoke("Die", 2f);
    }
    
    void OnDisable()
    {
        CancelInvoke("Die");
    }
	
	void Die()
    {
        CObjectPool.current.PoolObject(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("Enemy"))
        {
            if (!col.name.Equals("SandBag"))
            {
                SendDamage(col, _damage);
            }
        }
        else if (col.tag.Equals("SaveBox"))
        {
            PlayerPrefs.SetFloat("XPOS", _player.transform.position.x);
            PlayerPrefs.SetFloat("YPOS", _player.transform.position.y);
            //PlayerPrefs.SetInt("BGMNUM",);
            PlayerPrefs.Save();
        }
        _animator.SetTrigger("Destroy");
        _rigidbody2d.velocity = new Vector2(0f, 0f);
        _circleCollider2d.enabled = false;
        StartCoroutine("BulletDestroyCoroutine");
    }

    protected override void SendDamage(Collider2D col, int _damage)
    {
        base.SendDamage(col, _damage);
    }

    IEnumerator BulletDestroyCoroutine()
    {
        while ( 0 < _spriteRenderer.color.a)
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, _spriteRenderer.color.a - 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}