using UnityEngine;
using System.Collections;

public class CBgmSet : MonoBehaviour
{
    CSoundManager _soundManager;

    void Start()
    {
        _soundManager = GameObject.Find("MainCamera").GetComponent<CSoundManager>();
    }

    protected virtual void SetBgm(int num)
    {
        _soundManager.PlayBgm(num);
    }
}

