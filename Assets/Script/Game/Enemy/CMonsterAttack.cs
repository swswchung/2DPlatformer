using UnityEngine;
using System.Collections;

public class CMonsterAttack : MonoBehaviour, IMonsterAttack {

    protected Transform _attackPoint;
    protected Animator _animator;
    protected CCharacterState _monsterState;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _attackPoint = transform.FindChild("AttackPoint").transform;
        _monsterState = GetComponent<CCharacterState>();
    }

    public virtual void Attack()
    {
        
    }

    public virtual void AttackReady()
    {
        _monsterState.state = CCharacterState.State.Attack;

        _animator.SetBool("Attack", true);
    }

    public virtual void AttackFinish()
    {
        _monsterState.state = CCharacterState.State.Idle;

        _animator.SetBool("Attack", false);
    }
}
