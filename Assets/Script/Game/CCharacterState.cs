using UnityEngine;
using System.Collections;

public class CCharacterState : MonoBehaviour {

    public LayerMask _targetMask;
    public float _hp;
    public bool _isDie = false;
    public bool _isRightDir = false;

    public enum State
    {
        Idle,
        Move,
        Attack,
        Damage,
        Flip,           //회전중      
        Stun            //행동불가상태
    };
    public State _state;

    public State state
    {
        get { return this._state; }
        set { this._state = value; }
    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;

        theScale.x *= -1;
        transform.localScale = theScale;

        _isRightDir = !_isRightDir;
    }
}
