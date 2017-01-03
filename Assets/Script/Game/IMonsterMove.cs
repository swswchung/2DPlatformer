using UnityEngine;
using System.Collections;

public interface IMonsterMove {
    void Move();
    void Flip();
    void IdleTimeStop(float time);
    void IdleStop();                
    void AttackStop();              
    void MoveResume();             
}
