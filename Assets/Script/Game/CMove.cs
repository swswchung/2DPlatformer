using UnityEngine;
using System.Collections;

public class CMove : MonoBehaviour {

    protected CCharacterState _characterState;

    public virtual void Flip()
    {
        _characterState.Flip();
    }
}
