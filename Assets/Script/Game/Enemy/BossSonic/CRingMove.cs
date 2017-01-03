using UnityEngine;
using System.Collections;

public class CRingMove : MonoBehaviour {

    Rigidbody2D _rigidBody2d;

    void Awake()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {

        _rigidBody2d.AddForce(new Vector2(Random.Range(-100f,100f),150f));
        Invoke("DestroyRing",3.5f);
	}

    void DestroyRing()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player") && !col.gameObject.GetComponent<CCharacterState>()._isDie)
        {
            col.collider.SendMessage("Damage", 1f);
            GameObject.Find("BossSonic").GetComponent<CSonicAnimationSound>().Voice(8);
        }
    }
}