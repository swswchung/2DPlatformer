using UnityEngine;
using System.Collections;

public interface IInputMove
{
    void InputMove();                       //이동키 입력
    void Move(float move);                 //이동
    void InputJump();                       //점프키 입력
    void Jump(float jumpPower);         //점프함수
    void Grounding(bool isGround);  //땅에있는지 체크
}
