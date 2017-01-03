using UnityEngine;
using System.Collections;

public class CShotGun : CGun {

    public GameObject _shotGunEffect;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.X) && (!_isDelay && _bulletCount != 0))
        {//샷건은 재장전중에 발포가능- 재장전은 취소됨.
            StopCoroutine("ShotGunReloadCoroutine");
            Shot();
            GameObject.Find("Player").GetComponent<CPlayerSound>().EffectSound(1);
            _isReload = false;
        }

        if ((_bulletCount == 0  || (_bulletCount < _maxBullet && Input.GetKeyDown(KeyCode.R))) && (!_isReload && !_isDelay))
        {//총알이 0이되면 자동으로 재장전, 또는 R키를 누르면 재장전됨
            StartCoroutine("ShotGunReloadCoroutine");
            _isReload = true;
        }
    }

    protected override void Shot()
    {
        GameObject obj = CObjectPool.current.GetObject(_shotGunEffect);

        base.Shot();
        _isDelay = true;
        obj.transform.position = transform.position;
        obj.SetActive(true);

        StartCoroutine("ShotDelayCoroutine");
    }

    IEnumerator ShotGunReloadCoroutine()
    {
        while (_bulletCount != _maxBullet)
        {
            yield return new WaitForSeconds(_reloadTime);
            _bulletCount++;
        }
        _isReload = false;
    }
}
