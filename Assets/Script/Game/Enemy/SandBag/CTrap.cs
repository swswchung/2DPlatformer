using UnityEngine;
using System.Collections;

public class CTrap : MonoBehaviour {

    public GameObject _trap;
    bool _isRyuDie;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        _isRyuDie = GameObject.Find("SandBag").GetComponent<CSandBag>()._isDie;
        if(col.tag.Equals("Player") && !_isRyuDie)
        {
            //트랩작동
            Instantiate(_trap, new Vector2(transform.position.x - 12f, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
