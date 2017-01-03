using UnityEngine;
using System.Collections;

public class CGunPickUp : MonoBehaviour {
    
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("Player"))
        {
            col.SendMessage("PickUpGun", gameObject.tag);
            Destroy(gameObject);
        }
    }
}
