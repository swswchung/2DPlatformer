using UnityEngine;
using System.Collections;

public class CBulletDamage : MonoBehaviour {

    protected virtual void SendDamage(Collider2D col, int _damage)
    {
        col.SendMessage("Damage", _damage);
    }
}
