using UnityEngine;
using System.Collections;

public class CMonsterDamage : MonoBehaviour , IDamage{

    protected SpriteRenderer _spriteRenderer;
    protected CCharacterState _monsterState;
    Rigidbody2D _rigidbody2d;

    protected virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _monsterState = GetComponent<CCharacterState>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public virtual void Damage(int damage)
    {
        _monsterState._hp -= damage;//각 총기의  데미지만큼 체력을 떨굼

        if(_monsterState._hp <= 0)
        {
            Destroy(gameObject);
        }
        StartCoroutine(DamageEffectCoroutine());
    }

    public IEnumerator DamageEffectCoroutine()
    {
        _spriteRenderer.material.color = new Color(7f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.material.color = new Color(1, 1f, 1f, 1f);
    }
}
