using UnityEngine;
using System.Collections;

public class CSmoke : CBulletDamage {

    Rigidbody2D _rigidbody2d;

    public int _damage;
    public float _damageRange;
    Transform _colPos;

    // Use this for initialization
    void Awake () {
        _rigidbody2d = GetComponent<Rigidbody2D>();
	}
    
    void OnEnable()
    {
        float _movedir = (GameObject.Find("Player").GetComponent<CCharacterState>()._isRightDir) ? 1 : -1;
        Vector3 theScale = transform.localScale;
        theScale.x = (_movedir < 0) ? -1 : 1;
        transform.localScale = theScale;
        
        Invoke("Die", 0.35f);
    }

    void OnDisable()
    {
        CancelInvoke("Die");
    }

    void Die()
    {
        CObjectPool.current.PoolObject(gameObject);
    }

    void Attack()
    {
        _colPos = GameObject.Find("ShotGunColPos").transform;
        /*Collider2D[] colliders = Physics2D.OverlapCircleAll(_colPos.position,
            _damageRange, 1 << LayerMask.NameToLayer("Enemy"));*/

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_colPos.position,
            _damageRange);

        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy" )
            {
                SendDamage(collider, _damage);
            }
            if (collider.tag == "EnemyBullet")
            {
                Destroy(collider.gameObject);
            }
        }
    }

    protected override void SendDamage(Collider2D col, int _damage)
    {
        base.SendDamage(col, _damage);
    }
}
