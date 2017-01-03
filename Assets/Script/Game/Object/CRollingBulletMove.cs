using UnityEngine;
using System.Collections;
using System;

public class CRollingBulletMove : CBullet {
    

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update () {
	
	}

    protected override void Init(bool isRightDir)
    {
        base.Init(isRightDir);
        Move();
    }

    public override void Move()
    {
        _rigidbody2d.velocity = new Vector2(_dir * _speed, _rigidbody2d.velocity.y);
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Wall"))
        {
            _dir = _dir * -1;
            _rigidbody2d.velocity = new Vector2(_dir * _speed, _rigidbody2d.velocity.y);
        }
        base.OnCollisionEnter2D(col);
    }
}
