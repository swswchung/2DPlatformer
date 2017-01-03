using UnityEngine;
using System.Collections;

public class CMonsterTargetChecker : MonoBehaviour {

    public CCharacterState _monsterState;
    public CCharacterState.State _checkState;
    public float _checkRange;
    protected Transform _attackPoint;
    public bool _preDir = false;

    public Transform _playerPos;

    void Awake()
    {
        _monsterState = GetComponent<CCharacterState>();
        _attackPoint = transform.FindChild("AttackPoint").transform;
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //타입 2,3은 Circle 타입1은 Front

    public void CircleAreaTargetCheck(IMonsterAttack monsterAttack)
    {
        StartCoroutine("CircleAreaTargetCheckCoroutine",monsterAttack);
    }

    public IEnumerator CircleAreaTargetCheckCoroutine(IMonsterAttack monsterAttack)
    {
        while(_monsterState.state == _checkState)
        {
            float distance = Vector2.Distance(_attackPoint.position, _playerPos.position);

            if(distance < _checkRange)
            {
                if(((_playerPos.position.x < transform.position.x) && _monsterState._isRightDir)
                  || ((transform.position.x < _playerPos.position.x) && !_monsterState._isRightDir))
                {
                    _monsterState.Flip();
                }
                monsterAttack.AttackReady();
            }

            yield return null;
        }
    }

    public void FrontTargetCheck(IMonsterAttack monsterAttack)
    {
        StartCoroutine("FrontTargetCheckCoroutine", monsterAttack);
    }

    public IEnumerator FrontTargetCheckCoroutine(IMonsterAttack monsterAttack)
    {
        while(_monsterState.state == _checkState)
        {
            Vector2 endPos = new Vector2(_attackPoint.position.x -
                ((_monsterState._isRightDir) ? -_checkRange : _checkRange),
                _attackPoint.position.y);

            Debug.DrawLine(_attackPoint.position, endPos, Color.green);

            RaycastHit2D hitInfo = Physics2D.Linecast(_attackPoint.position, endPos, _monsterState._targetMask);

            if(hitInfo.collider != null)
            {
                monsterAttack.AttackReady();
            }

            yield return null;
        }
    }
}
