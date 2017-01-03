using UnityEngine;
using System.Collections;

public class CMonsterMove : CMove, IMonsterMove {

    protected Animator _animator;
    protected Rigidbody2D _rigidbody2d;
    protected CCharacterState _monsterState;

    public float _prevMoveSpeed;
    public float _moveSpeed;

    protected GameObject _player;

    protected virtual void Awake()
    {
        _characterState = GetComponent<CCharacterState>();
        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _monsterState = GetComponent<CCharacterState>();
    }

    protected virtual void Start()
    {
        _prevMoveSpeed = _moveSpeed;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        _monsterState.state = CCharacterState.State.Move;
    }

    public virtual void IdleTimeStop(float time)
    {
        if (_monsterState.state == CCharacterState.State.Idle) return;

        StartCoroutine(StopIdleDelayCoroutine(time));
    }

    public virtual IEnumerator StopIdleDelayCoroutine(float time)
    {
        IdleStop();

        yield return new WaitForSeconds(time);

        MoveResume();
    }

    public virtual void IdleStop()
    {
        _monsterState.state = CCharacterState.State.Idle;

        _moveSpeed = 0;
    }

    public virtual void MoveResume()
    {
        _moveSpeed = _prevMoveSpeed;

        _monsterState.state = CCharacterState.State.Move;
    }

    public virtual void AttackStop()
    {
        _moveSpeed = 0;
    }
}
