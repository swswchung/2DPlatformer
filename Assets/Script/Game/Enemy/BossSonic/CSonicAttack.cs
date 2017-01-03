using UnityEngine;
using System.Collections;

public class CSonicAttack : MonoBehaviour {

    CCharacterState _state;
    Rigidbody2D _rigidbody2d;
    Animator _animator;
    public GameObject _ring;
    public GameObject _lookRingManager;
    public GameObject _laserBeam;

    Transform _shotPos;
    
    float _dir;
    
	void Awake()
    {
        _state = GetComponent<CCharacterState>();
        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _shotPos = GameObject.Find("LaserPoint").transform;
    }
    

    void StartBoss()
    {
        StartCoroutine("FirstAttack");
    }

    IEnumerator FirstAttack()
    {
        yield return new WaitForSeconds(1.5f);
        _animator.SetTrigger("MeetThePlayer");
        yield return new WaitForSeconds(5f);
        int num = 0;
        while (num != 1)
        {
            if (transform.position.x < 141f)
            {
                transform.position = new Vector2(160f, transform.position.y);
                num++;
            }
            _rigidbody2d.AddForce(new Vector2(-2000f, 0f));
            yield return new WaitForSeconds(1f);
            
        }

        _state.Flip();

        num = 0;

        while(num != 1)
        {
            _rigidbody2d.AddForce(new Vector2(2000f, 0f));
            yield return new WaitForSeconds(1f);
            
            if (170f < transform.position.x)
            {
                transform.position = new Vector2(141f, transform.position.y);
                num++;
            }
        }
       
        yield return new WaitForSeconds(1f);
        _state.Flip();
        _rigidbody2d.gravityScale = 0f;
        transform.position = new Vector2(160f, -49f);
        
        _rigidbody2d.velocity = new Vector2(-14f, 0);
        
        StartCoroutine("SecondAttackMove");
    }

    IEnumerator SecondAttack()
    {
        while (true)
        {
            Instantiate(_ring, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator SecondAttackMove()
    {
        GetComponent<CSonicAnimationSound>().Voice(2);
        float dir;
        StopCoroutine("FirstAttack");
        StartCoroutine("SecondAttack");
        yield return new WaitForSeconds(1f);
        while (true)
        {
            _state.Flip();
            dir = (_state._isRightDir) ? 1 : -1;
            _rigidbody2d.velocity = new Vector2(5f * dir,0f);
            yield return new WaitForSeconds(1.5f);
        }
    }

    void SuperSonic()
    {
        if(!_state._isRightDir)
        {
            _state.Flip();
        }
        _rigidbody2d.velocity = Vector2.zero;
        _animator.SetTrigger("SuperSonic");
        StopCoroutine("SecondAttack");
        StopCoroutine("SecondAttackMove");
        StartCoroutine("SuperSonicFirstAttackMove");
    }

    IEnumerator SuperSonicFirstAttackMove()//
    {
        transform.position = new Vector2(150f, -50f);
        yield return new WaitForSeconds(3.0f);
        
        _rigidbody2d.velocity = new Vector2(100f * 1.0f, 0f);
        yield return new WaitForSeconds(2f);

        _state.Flip();
        transform.position = new Vector3(160f,-50f,0f);
        _rigidbody2d.velocity = new Vector2(100f * -1.0f, 0f);
        Instantiate(_lookRingManager,new Vector3(150f,-50f,0f),Quaternion.identity);
        yield return new WaitForSeconds(15f);

        _state.Flip();
        transform.position = new Vector3(140f, -50f, 0f);
        _rigidbody2d.velocity = new Vector2(100f * 1.0f, 0f);
        Instantiate(_lookRingManager, new Vector3(150f, -50f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(15f);

        transform.position = new Vector3(140f, -53.8f, 0f);
        _rigidbody2d.velocity = Vector2.zero;

        _animator.SetTrigger("LaserBeam");
        _rigidbody2d.velocity = new Vector2(11.5f, 0);
        
    }

    public void LaserFlip()
    {
        _state.Flip();
        _rigidbody2d.velocity = Vector2.zero;
    }

    public void LaserBeam()
    {
        
        Instantiate(_laserBeam, _shotPos.transform.position, Quaternion.identity);

        Invoke("SuperSonicAttackMove", 3f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            float dir = (_state._isRightDir) ? 1 : -1;
            col.collider.SendMessage("Damage", dir);
            StopAllCoroutines();
            _rigidbody2d.velocity = Vector2.zero;
            GetComponent<CSonicAnimationSound>().Voice(8);
        }
    }
}
