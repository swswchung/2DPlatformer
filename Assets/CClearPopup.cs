using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using GameData;

public class CClearPopup : MonoBehaviour {

    public Text _messageText;
    string _userId;

    public void ShowMessage()
    {
        gameObject.SetActive(true);

        _messageText.text = PlayerPrefs.GetInt("DEATH_COUNT").ToString();
        StartCoroutine("GameScoreUpdateNetCoroutine");
    }

    public void OnOKButtonClick()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Rank");
    }

    IEnumerator GameScoreUpdateNetCoroutine()
    {
        string strUserData = PlayerPrefs.GetString("USER_DATA");

        Dictionary<string, object> userData = MiniJSON.jsonDecode(strUserData) as Dictionary<string, object>;

        _userId = userData["user_id"].ToString();

        string url = "http://52.78.80.216/projectphp/update.php";

        WWWForm form = new WWWForm();

        form.AddField("user_id", _userId);
        form.AddField("user_deathcount", PlayerPrefs.GetInt("DEATH_COUNT"));

        WWW www = new WWW(url, form);

        yield return www;

        if (www.error == null)
        {
            Dictionary<string, object> responseData =
            MiniJSON.jsonDecode(www.text.Trim()) as Dictionary<string, object>;

            string code = responseData["code"].ToString().Trim();
            //업데이트가 실패했다면
            if (code.Equals("UPDATE_FAIL"))
            {
                Debug.Log("점수 업데이트 실패");
            }
            else
            {
                Debug.Log("점수 업데이트 성공");
            }
        }
        else
        {
            Debug.Log("서버 연결이 실패");
        }
    }
}
