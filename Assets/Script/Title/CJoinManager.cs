using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using GameData;

public class CJoinManager : MonoBehaviour {

    public InputField _userIdInputField;
    public InputField _userPwInputField;
    public InputField _userRePwInputField;

    public Text _joinLogText;

    public CInfoMessagePopup _infoMessagePopup;

    // Use this for initialization
    void Start()
    {
        _joinLogText.text = "";
    }

    //회원 가입버튼 클릭
    public void OnOkJoinButtonClick()
    {
        if (_userIdInputField.text.Trim().Length <= 0 ||
            _userPwInputField.text.Trim().Length <= 0 ||
            _userRePwInputField.text.Trim().Length <= 0)
        {
            _joinLogText.text = "가입 정보를 모두 입력하세요.";
            return;
        }

        if (!_userPwInputField.text.Equals(_userRePwInputField.text))
        {
            _joinLogText.text = "비밀번호 확인 정보가 틀림";
            return;
        }
        StartCoroutine("JoinNetCoroutine");
    }

    IEnumerator JoinNetCoroutine()
    {
        string url = "http://52.78.80.216/projectphp/join.php";

        WWWForm form = new WWWForm();

        form.AddField("user_id", _userIdInputField.text);
        form.AddField("user_pw", _userPwInputField.text);

        WWW www = new WWW(url, form);

        yield return www;

        if (www.error == null)
        {
            Dictionary<string, object> responseData =
            MiniJSON.jsonDecode(www.text.Trim()) as Dictionary<string, object>;

            string code = responseData["code"].ToString().Trim();
            //로그인이 실패했다면
            if (code.Equals("JOIN_FAIL"))
            {
                //팝업을 띄움
                _joinLogText.text = "회원가입에 실패함.";
                //코루틴을 중단
                yield break;
            }
            else if (code.Equals("EXIST_USER_ID"))//이미 유저 아이디가 존재한다면
            {
                _joinLogText.text = "이미 아이디가 존재함.";
                yield break;
            }

            gameObject.SetActive(false);
            _infoMessagePopup.ShowMessage("회원가입 성공");
            ClearInputField();
        }
        else
        {
            _joinLogText.text = "서버 연결이 실패";
        }
        _joinLogText.text = "";
    }

    //회원가입 취소버튼 클릭
    public void OnCancleJoinPopupButtonClick()
    {
        gameObject.SetActive(false);
        ClearInputField();
        _joinLogText.text = "";
    }

    void ClearInputField()
    {
        _userIdInputField.text = "";
        _userPwInputField.text = "";
        _userRePwInputField.text = "";
    }

}
