using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CGun : MonoBehaviour {

    /// <summary>
    ///  TEXT   ///
    /// </summary>
    public Text _gunNameText;
    public Text _bulletText;
    public Text _maxBulletText;
    public Text _reloadText;
    public Image _reloadBar;

    /// <summary>
    /// Inspector
    /// </summary>
    protected Transform _shotPos;
    protected Animator _playerAnimator;

    /// <summary>
    /// 변수
    /// </summary>
    public bool _isReload = false;
    public bool _isDelay;
    public int _maxBullet;
    public int _bulletCount;
    public float _shotDelayTime;
    public float _reloadTime;
    
    CCharacterState _playerState;

    protected virtual void Awake()
    {
        _playerState = GetComponent<CCharacterState>();
    }

    protected virtual void Shot()
    {
        _bulletCount--;
        _playerAnimator.SetTrigger("Shoot");
    }

    protected virtual void Start()
    {
        _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        _gunNameText.text = gameObject.name;
        _bulletText.text = _bulletCount.ToString();
        _maxBulletText.text = _maxBullet.ToString();

        if(_isDelay || _isReload)
        {
            _gunNameText.color = new Color(1f, 0f, 0f);
            _bulletText.color = new Color(1f, 0f, 0f);
            _maxBulletText.color = new Color(1f, 0f, 0f);
        }
        else
        {
            _gunNameText.color = new Color(0f, 1f, 0f);
            _bulletText.color = new Color(0f, 1f, 0f);
            _maxBulletText.color = new Color(0f, 1f, 0f);
        }
    }

    protected virtual void  Reload()
    {
        StartCoroutine("ReloadCoroutine");
    }

    IEnumerator ReloadCoroutine()
    {
        //_bulletCount = _maxBullet;
        //_shotReady = true;
        _reloadText.text = "Reloading";
        yield return new WaitForSeconds(_reloadTime);
        _bulletCount = _maxBullet;
        _isReload = false;
        _reloadText.text = "";
    }

    IEnumerator ShotDelayCoroutine()
    {
        yield return new WaitForSeconds(_shotDelayTime);
        _isDelay = false;
    }

    void OnDisable()
    {
        _isDelay = false;
        _isReload = false;
    }
}