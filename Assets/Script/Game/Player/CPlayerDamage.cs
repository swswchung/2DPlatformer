using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CPlayerDamage : MonoBehaviour
{

    /// <summary>
    /// 한대만 맞아도 사망 ///
    /// </summary>
    /// 
    CCharacterState _state;
    Animator _animator;
    Rigidbody2D _rigidbody2d;
    BoxCollider2D _boxCollider2d;
    public Image _deathImage;
    public Text _deathCountText;

    public int _deathCount;

    void Start()
    {
        _state = GetComponent<CCharacterState>();
        _animator = GetComponent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _boxCollider2d = GetComponent<BoxCollider2D>();
        _deathCount = PlayerPrefs.GetInt("DEATH_COUNT", 0);
        _deathCountText.text = _deathCount.ToString();
    }

    public void Damage(float dir)
    {
        if (!_state._isDie)
        {
            GameObject.Find("MainCamera").GetComponent<CSoundManager>().PlayBgm(4);
            _state._isDie = true;
            _animator.SetTrigger("Death");

            _deathCount++;
            PlayerPrefs.SetInt("DEATH_COUNT", _deathCount);
            _deathCountText.text = _deathCount.ToString();

            _boxCollider2d.isTrigger = true;
            _rigidbody2d.velocity = Vector2.zero;
            _rigidbody2d.AddForce(new Vector2(dir * 300f, 600f));

            GetComponent<CPlayerMove>().enabled = false;
            GetComponent<CPlayerChangeWeapon>().enabled = false;
            //R버튼을 누르라는 이미지를 띄움.
            StartCoroutine("DieImageCoroutine");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_state._isDie)
        {
            _boxCollider2d.isTrigger = false;
            _rigidbody2d.velocity = Vector2.zero;   
        }
    }

    IEnumerator DieImageCoroutine()
    {
        yield return new WaitForSeconds(2f);
        float a = 0f;

        while (a < 1f)
        {
            a += 0.1f;
            yield return new WaitForSeconds(0.1f);
            _deathImage.color = new Color(1f, 1f, 1f, a);
        }
    }
}
