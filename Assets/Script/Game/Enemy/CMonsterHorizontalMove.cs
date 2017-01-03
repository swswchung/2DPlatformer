using UnityEngine;
using System.Collections;

public class CMonsterHorizontalMove : CMonsterMove {

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    public override void Move()
    {
        base.Move();

        _rigidbody2d.velocity = new Vector2((_monsterState._isRightDir) ? 
            _moveSpeed : -_moveSpeed, _rigidbody2d.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "TurnPoint")
        {
            Flip();
        }
    }
}
