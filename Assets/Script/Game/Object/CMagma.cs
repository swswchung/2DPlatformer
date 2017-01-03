using UnityEngine;
using System.Collections;

public class CMagma : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D col)
    {
        col.SendMessage("Damage", 1f);
    }
}
