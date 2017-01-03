using UnityEngine;
using System.Collections;

public class CPistol : CGun {

    public GameObject _bullet;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.X) && (!_isDelay && !_isReload))
        {
            GameObject.Find("Player").GetComponent<CPlayerSound>().EffectSound(0);
            Shot();
        }
        else if((_bulletCount == 0  || (_bulletCount < _maxBullet && Input.GetKeyDown(KeyCode.R))) && !_isReload)
        {//총알이 0이되면 자동으로 재장전, 또는 R키를 누르면 재장전됨
            Reload();
            //StartCoroutine("ReloadCoroutine");
            _isReload = true;
        }
	}

    protected override void Shot()
    {
        GameObject obj = CObjectPool.current.GetObject(_bullet);
        
        obj.transform.position = transform.position;
        obj.SetActive(true);

        _isDelay = true;
        base.Shot();

        StartCoroutine("ShotDelayCoroutine");
    }
}