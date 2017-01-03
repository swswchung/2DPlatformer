using UnityEngine;
using System.Collections;

public interface IMonsterAttack {
    void AttackReady();
    void Attack();
    void AttackFinish();
}
