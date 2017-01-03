using UnityEngine;
using System.Collections;

public class CMonsterShot : CMonsterAttack {

    public Object _bullet;

    protected CMonsterTargetChecker _targetChecker;

    public enum CheckType { FRONT,CIRCLE };
    public CheckType _checkType = CheckType.FRONT;

    protected override void Awake()
    {
        base.Awake();

        _targetChecker = GetComponent<CMonsterTargetChecker>();
    }

    // Use this for initialization
    void Start()
    {
        StartTargetChecker();
    }

    void StartTargetChecker()
    {
        switch (_checkType)
        {
            case CheckType.FRONT:
                _targetChecker.FrontTargetCheck(this);
                break;
            case CheckType.CIRCLE:
                _targetChecker.CircleAreaTargetCheck(this);
                break;
        }
    }

    public override void AttackReady()
    {
        base.AttackReady();
    }

    public override void Attack()
    {
        GameObject bullet = Instantiate(_bullet, _attackPoint.position, Quaternion.identity) as GameObject;
        bullet.SendMessage("Init", _monsterState._isRightDir);
        base.Attack();
    }

    public override void AttackFinish()
    {
        base.AttackFinish();

        StartTargetChecker();
    }

    public virtual void AttackAnimationEvent()
    {
        Attack();
    }

    public virtual void AttackFinishAnimationEvent()
    {
        AttackFinish();
    }
}
