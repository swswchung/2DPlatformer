using UnityEngine;
using System.Collections;

public class COpenBossStage : MonoBehaviour {

    public GameObject _door;
    public bool _isCol = false;
    
	// Update is called once per frame
	void Update () {
        OpenDoor();
	}

    void OpenDoor()
    {
        if(_isCol)
        {
            _door.transform.Translate(Vector2.up * 2f * Time.deltaTime);
            if(-39.7f < _door.transform.position.y)
            {
                _door.transform.position = new Vector2(_door.transform.position.x, -39.7f);
            }
        }
        else if(!_isCol)
        {
            _door.transform.Translate(Vector2.down * 2f * Time.deltaTime);
            if (_door.transform.position.y <= -49.31f)
            {
                _door.transform.position = new Vector2(_door.transform.position.x, -49.31f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            _isCol = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            _isCol = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            _isCol = false;
        }
    }
}
