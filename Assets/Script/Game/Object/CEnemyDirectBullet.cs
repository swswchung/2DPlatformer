using UnityEngine;
using System.Collections;

public class CEnemyDirectBullet : CBullet {

    Transform _playerPos; 

    protected override void Start()
    {
        base.Start();
    }

    // 직선 총알 초기화(방향)
    protected override void Init(bool isRightDir)
    {
        _playerPos = GameObject.Find("Player").GetComponent<Transform>();
        // 직선 총알 초기화
        base.Init(isRightDir);
        //Move(); // 총알 이동
        Vector2 dir = _playerPos.transform.position - transform.position;

        float angle = Vector2.Angle(-transform.up, dir.normalized);

        //Debug.Log(angle);

        //회전 방향에 따른 수직벡터를 구함
        Vector3 cross = Vector3.Cross(-transform.up, dir.normalized);

        //z수직 벡터가 음수일 경우 360에서 뺌
        if (cross.z < 0)
        {
            angle = 360f - angle;
        }

        if(transform.position.x < _playerPos.position.x)
        {
            angle += 180f;
        }
        angle += 90f;
        transform.Rotate(0f, 0f, angle);
    }

    void Update()
    {
        Move();
    }

    // 총알 이동을 처리함
    public override void Move()
    {
        // 지정한 방향과 속도로 총알이 이동함

        transform.Translate(Vector2.right * _dir * _speed * Time.deltaTime);
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        Destroy(gameObject);
    }
}
