using UnityEngine;
using System.Collections;

public abstract class CBullet : MonoBehaviour
{
    //10초뒤 사라지는것과, 플레이어에 충돌시 게임종료만 구현
    public float _dir;
    public float _speed;
    protected Rigidbody2D _rigidbody2d;

    protected virtual void Init(bool isRightDir)
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _dir = (isRightDir) ? 1 : -1;
    }

    protected virtual void Start()
    {
        Invoke("DieInvoke", 10f);
    }

    public abstract void Move();

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            col.collider.SendMessage("Damage", _dir);
            Destroy(gameObject);
        }
    }
    
    void DieInvoke()
    {
        Destroy(gameObject);
    }
}
