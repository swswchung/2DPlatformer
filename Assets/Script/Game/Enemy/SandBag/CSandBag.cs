using UnityEngine;
using System.Collections;

public class CSandBag : MonoBehaviour {

    Animator _animator;
    Rigidbody2D _rigidbody2d;
    [SerializeField]
    GameObject _trap;
    public bool _isDie = false;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("PlayerBullet") && !_isDie)
        {
            _rigidbody2d.isKinematic = false;
            _isDie = true;
            _animator.SetTrigger("Die");
            _rigidbody2d.AddForce(new Vector2(200f, 400f));
            StartCoroutine("DieCoroutine");
        }
    }

    IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(5f);
        Destroy(_trap);
        Destroy(gameObject);
    }
}
