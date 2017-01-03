using UnityEngine;
using System.Collections;

public class CStageBgmSet : CBgmSet {

    public int _bgmNum;
    bool _isCol = false;

	void OnCollisionEnter2D(Collision2D col)
    {
        if (_isCol == false && col.gameObject.tag.Equals("Player"))
        {
            _isCol = true;
            base.SetBgm(_bgmNum);
        }
    }
}
