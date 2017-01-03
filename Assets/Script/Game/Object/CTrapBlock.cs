using UnityEngine;
using System.Collections;

public class CTrapBlock : MonoBehaviour {

    Rigidbody2D _rigidbody2d;
    BoxCollider2D _boxCollider2d;

	// Use this for initialization
	void Start () {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _boxCollider2d = GetComponent<BoxCollider2D>();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            _rigidbody2d.gravityScale = 10f;
            Invoke("DestroyInvoke",3f);
            _boxCollider2d.enabled = false;
        }
    }

    void DestroyInvoke()
    {
        Destroy(gameObject);
    }
}
