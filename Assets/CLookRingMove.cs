using UnityEngine;
using System.Collections;

public class CLookRingMove : LookTarget {

    Transform _playerPos;
    SpriteRenderer _spriteRenderer;
    bool _move = false;
    
	// Use this for initialization
	void Start () {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Ini();
        _spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine("Ready");
	}

    void Ini()
    {
        _playerPos = GameObject.Find("Player").GetComponent<Transform>();
        

    }

    IEnumerator Ready()
    {
        float a = 0.0f;
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            a += 0.1f;
            
            _spriteRenderer.color = new Color(1f,1f,1f,a);
            if(1.0f < a)
            {
                break;
            }
        }

        yield return new WaitForSeconds(1.0f);
        _move = true;
        Invoke("DestroyRing", 3f);
    }

    // Update is called once per frame
    void Update ()
    {
        if (!_move)
        {
            LookAt(_playerPos.transform.position);
        }
        if (_move)
        {
            Move();
        }
    }

    void Move()
    {
        transform.Translate(Vector2.up * 5f * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
        if (col.gameObject.tag.Equals("Player"))
        {
            col.collider.SendMessage("Damage", 1f);
            StopAllCoroutines();
        }
    }

    void DestroyRing()
    {
        Destroy(gameObject);
    }
}
