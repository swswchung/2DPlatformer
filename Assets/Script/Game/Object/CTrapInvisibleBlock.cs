using UnityEngine;
using System.Collections;

public class CTrapInvisibleBlock : MonoBehaviour {

    SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start () {
        _spriteRenderer = GetComponent<SpriteRenderer>();
	}
    
    void OnCollisionEnter2D(Collision2D col)
    {
        col.rigidbody.AddForce(new Vector2(0f, -1000f));
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
