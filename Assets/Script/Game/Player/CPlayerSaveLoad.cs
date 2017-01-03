using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CPlayerSaveLoad : MonoBehaviour {

    float x_pos, y_pos;
    GameObject _camera;

	// Use this for initialization
	void Start () {

        int bgmNum = PlayerPrefs.GetInt("BGMNUM");
        GameObject.Find("MainCamera").GetComponent<CSoundManager>().PlayBgm(bgmNum);

        int pistol, shotgun;
        pistol = PlayerPrefs.GetInt("SavePistol");
        shotgun = PlayerPrefs.GetInt("SaveShotGun");

        if(pistol == 1)
        {
            SendMessage("PickUpGun","Pistol");
        }
        if(shotgun == 1)
        {
            SendMessage("PickUpGun", "ShotGun");
        }

        x_pos = PlayerPrefs.GetFloat("XPOS");
        y_pos = PlayerPrefs.GetFloat("YPOS");

        transform.position = new Vector3(x_pos, y_pos);

        //얻어낸 x,y값으로 카메라의 위치를 계산.

        float xmok , ymok;

        //좌표에 맞춰 몫을 구함d
        xmok = (int)(x_pos / 12.5f);
        ymok = (int)(y_pos / 10f);

        if ((7.75f < (xmok * 12.5f - x_pos)) || (xmok * 12.5f - x_pos) < -7.75f)
        {
            xmok++;
        }

        if(5f < (ymok * 10f - y_pos))
        {
            ymok--;
        }
        
        _camera = GameObject.Find("MainCamera");
        _camera.transform.position = new Vector3(xmok * 12.5f, ymok * 10f, _camera.transform.position.z);
	}
	
    //R키를누르면 세이브위치에서 재시작. 세이브기록이 없으면 0,0좌표에서 시작
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("Game");
        }
	}
}
