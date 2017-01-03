using UnityEngine;
using System.Collections;

public class CHaMove : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * 10 * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("Player"))
        {
            col.SendMessage("Damage" ,1);
        }
    }
}
