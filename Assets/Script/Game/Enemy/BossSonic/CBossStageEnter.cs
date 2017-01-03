using UnityEngine;
using System.Collections;

public class CBossStageEnter : MonoBehaviour {

    GameObject _sonic;
    GameObject _player;
    bool _isCol = false;

    void Start()
    {
        _sonic = GameObject.Find("BossSonic");
        _player = GameObject.Find("Player");
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("Player") && !_isCol)
        {
            GameObject.Find("MainCamera").GetComponent<CSoundManager>().Boss();
            _player.GetComponent<CMove>().enabled = false;
            _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            StartCoroutine("WaitBoss");
            _isCol = true;
            _sonic.SendMessage("StartBoss");
        }
    }

    IEnumerator WaitBoss()
    {
        yield return new WaitForSeconds(5f);

        _player.GetComponent<CMove>().enabled = true;
        _player.GetComponent<CMove>().enabled = true;

        Destroy(gameObject);
    }
}
