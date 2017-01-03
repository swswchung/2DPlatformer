using UnityEngine;
using System.Collections;

public class CSonicDamage : CMonsterDamage {

    bool _isSuper;
    Animator _animator;

    public CClearPopup _popup;


    protected override void Awake()
    {
        _animator = GetComponent<Animator>();
        base.Awake();
    }

    public override void Damage(int damage)
    {
        _monsterState._hp -= damage;//각 총기의  데미지만큼 체력을 떨굼
        if(_monsterState._hp <= 50 && !_isSuper)
        {
            SendMessage("SuperSonic");
            GetComponent<CSonicAnimationSound>().Voice(7);
            _isSuper = true;
        }
        if (_monsterState._hp <= 0)
        {
            _animator.SetBool("IsDie", true);
            //클리어음악 재생 후 플레이어 조작불가하게 만들고 5초뒤 랭킹페이지 뜨게함
            GameObject.Find("MainCamera").GetComponent<CSoundManager>().PlayBgm(3);

            GameObject.Find("Player").GetComponent<CPlayerMove>().enabled = false;
            if(GameObject.Find("ShotGun") == null)
            {
                GameObject.Find("Pistol").GetComponent<CPistol>().enabled = false;
            }
            else
            {
                GameObject.Find("ShotGun").GetComponent<CShotGun>().enabled = false;
            }

            GetComponent<CSonicAnimationSound>().Voice(8);
            Invoke("Clear", 1f);
        }
        
        StartCoroutine(base.DamageEffectCoroutine());
    }
    
    void Clear()
    {
        _popup.ShowMessage();
    }

}
