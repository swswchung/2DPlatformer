using UnityEngine;
using System.Collections;

public class CLaser : MonoBehaviour {

    SpriteRenderer _spriteRenderer;
    
    // Use this for initialization
    void Start ()
    {
        Invoke("Die", 1f);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void Attack()
    {
        GameObject.Find("BossSonic").GetComponent<CSonicAnimationSound>().Voice(9);

        Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(125f, -52f), new Vector2(154f, -55f),
            1 << LayerMask.NameToLayer("Player"));
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Player")
            {
                collider.gameObject.SendMessage("Damage", -1f);
            }
        }
    }
}
