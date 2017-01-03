using UnityEngine;
using System.Collections;

public class CMonsterMoveAttack : CMonsterAttack {

    public Object _bulletPrefab;
    protected CMonsterTargetChecker _targetChecker;
    protected IMonsterMove _monsterMove;

    protected override void Awake()
    {
        base.Awake();

        _targetChecker = GetComponent<CMonsterTargetChecker>();

        _monsterMove = GetComponent<IMonsterMove>();
    }
    void Start()
    {
        _targetChecker.CircleAreaTargetCheck(this);
    }

    public override void AttackReady()
    {
        _monsterMove.AttackStop();
        base.AttackReady();
    }

    public override void Attack()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _attackPoint.position, Quaternion.identity) as GameObject;
        bullet.SendMessage("Init", _monsterState._isRightDir);
    }

    public override void AttackFinish()
    {
        base.AttackFinish();

        _monsterMove.MoveResume();

        _targetChecker.CircleAreaTargetCheck(this);
    }

    public void AttackAnimationEvent()
    {
        Attack();
    }

    public void AttackFinishAnimationEvent()
    {
        AttackFinish();
    }
}
