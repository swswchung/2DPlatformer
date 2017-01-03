using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;

using GameData;

public class CLoginManager : MonoBehaviour {

    public CJoinManager _joinManager;
    public InputField _userIdInputField;
    public InputField _userPwInputField;
    public CInfoMessagePopup _infoMessagePopup;

    public Text _logMessageText;

    // Use this for initialization
    void Start ()
    {
        _logMessageText.text = "";

    }

    //회원 가입 팝업 띄우기 버튼 클릭
    public void OnOpenJoinPopupButtonClick()
    {
        _joinManager.gameObject.SetActive(true);
    }

    public void OnLoginButtonClick()
    {
        if (_userIdInputField.text.Trim().Length <= 0)
        {
            _infoMessagePopup.ShowMessage("아이디를 입력하세요");
            return;
        }
        if (_userPwInputField.text.Trim().Length <= 0)
        {
            _infoMessagePopup.ShowMessage("비밀번호를 입력하세요");
            return;
        }

        StartCoroutine("LoginNetCoroutine");
    }


    IEnumerator LoginNetCoroutine()
    {
        string url = "http://52.78.80.216/projectphp/login.php";

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
            if (code.Equals("LOGIN_FAIL"))
            {
                //팝업을 띄움
                _infoMessagePopup.ShowMessage("로그인 정보가 틀립니다.");
                //코루틴을 중단
                yield break;
            }

            //성공시 유저의데이터정보를 PlayerPrefs에 저장
            Dictionary<string, object> userdata = responseData["data"] as Dictionary<string, object>;

            //유저 데이터 딕셔너리 객체를 다시 json 문자열로 변경
            string json_userdata = MiniJSON.jsonEncode(userdata);

            PlayerPrefs.SetString("USER_DATA", json_userdata/*userdata["user_id"]*/.ToString());
            PlayerPrefs.Save();

            //유저 데이터만 포함된 json문자열을 출력
            Debug.Log("유저 데이터 = " + json_userdata);

            SceneManager.LoadScene("Game");
        }
        else
        {
            _infoMessagePopup.ShowMessage("서버 연결이 실패");
        }
    }
    void ClearInputField()
    {
        _userIdInputField.text = "";
        _userPwInputField.text = "";
    }
}
