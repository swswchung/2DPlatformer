using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CIntro : MonoBehaviour {
    
    public GameObject _title;
    public Canvas _canvas;
    public GameObject _backGround;
    
    Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();   
	}
	
    void StartAnimation()
    {
        PlayerPrefs.DeleteAll();
        _title.SetActive(true);
        _canvas.gameObject.SetActive(true);
        _backGround.SetActive(true);
        Destroy(gameObject);
    }

}
