using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class CRowInfo : MonoBehaviour {

    public Text _userIdText;
    public Text _userBestDeathCount;

    public void SetRowInfo(Dictionary<string, object> rowInfoDic)
    {
        _userIdText.text = rowInfoDic["user_id"].ToString();
        _userBestDeathCount.text = rowInfoDic["user_deathcount"].ToString();
    }
}
