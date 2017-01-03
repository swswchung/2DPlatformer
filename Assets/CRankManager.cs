using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class CRankManager : MonoBehaviour {


    public GameObject _rowInfoPanelPrefab;

    public Transform _scrollViewContentTr;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("RankingNetCoroutine");
    }

    IEnumerator RankingNetCoroutine()
    {
        string url = "http://52.78.80.216/projectphp/rank.php";

        WWW www = new WWW(url);
        yield return www;

        if (www.error == null)
        {
            Dictionary<string, object> resData = GameData.MiniJSON.jsonDecode(www.text)
                as Dictionary<string, object>;

            string code = resData["code"].ToString();

            if (code.Trim() == "RANK_SUCCESS")
            {
                List<object> ranking_list = resData["rank"] as List<object>;

                Debug.Log("ranking list count => " + ranking_list.Count);

                //content 뷰의 크기 설정
                _scrollViewContentTr.GetComponent<RectTransform>().sizeDelta =
                    new Vector2(_scrollViewContentTr.GetComponent<RectTransform>().sizeDelta.x, 120f * ranking_list.Count);

                float posY = 0f;

                foreach (object row in ranking_list)
                {
                    Dictionary<string, object> rowInfoDic =
                        row as Dictionary<string, object>;
                    GameObject rowPanel = Instantiate(_rowInfoPanelPrefab, Vector2.zero, Quaternion.identity) as GameObject;

                    //생성한 로우패널 오브젝트를 스크롤뷰의 content의 자식으로 붙임
                    rowPanel.transform.SetParent(_scrollViewContentTr, false);

                    rowPanel.GetComponent<RectTransform>().localPosition = new Vector2(0f, posY);
                    posY -= 120f;

                    //로우 패널에 정보를 출력
                    rowPanel.SendMessage("SetRowInfo", rowInfoDic);
                }
            }
            else
            {
                Debug.Log("순위 조회 실패");
            }
        }
        else
        {
            Debug.Log("통신 실패");
        }
    }
}
