using UnityEngine;
using System.Collections;

public class CGenSonicBlock : MonoBehaviour {
    
    public GameObject _sonic;
    public Transform _genPos;
    

    void OnTriggerEnter2D(Collider2D col)
    {
        Invoke("SonicGen", 1f);
    }

    void SonicGen()
    {
        Instantiate(_sonic, _genPos.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
