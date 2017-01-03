using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CInfoMessagePopup : MonoBehaviour {

    public Text _InfoMessageText;

    //정보 메세지 팝업에 안내 메세지를 출력.
    public void ShowMessage(string msg)
    {
        gameObject.SetActive(true);

        _InfoMessageText.text = msg;
    }

    //정보 메세지 팝업의 확인버튼을 클릭함.
    public void OnOkButtonClick()
    {
        gameObject.SetActive(false);
    }
}
