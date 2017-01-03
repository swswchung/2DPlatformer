using UnityEngine;
using System.Collections;

public class CGrenadeMove : MonoBehaviour {

    Rigidbody2D _rigidbody2d;
    public float _damageRange;
    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        //플레이어가 바라보는 방향으로 던짐
        bool isRightDir = GameObject.Find("Player").GetComponent<CCharacterState>()._isRightDir;

        float dir = (isRightDir) ? 1 : -1;

        _rigidbody2d.AddForce(new Vector2(dir * 500f, 200f));
	}
	
    void OnTriggerEnter2D(Collider2D col)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position
            , _damageRange, 1 << LayerMask.NameToLayer("Enemy"));

        foreach (Collider2D collider in colliders)
        {
            if (col.tag == "Wall" || col.tag == "Enemy")
            {
                //이펙트 발생시키면서 주변에 피해를 입히고 destroy 또는 오브젝트풀에 넣음
                //Instantiate();
                collider.SendMessage("Damage",10f); //데미지별로 애니메이션을 재생함. ex) 1 = 일반 10 = 날라감 30 = 사라짐
                
                Destroy(gameObject);
                break;
            }
        }
    }
}
