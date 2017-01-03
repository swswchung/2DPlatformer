using UnityEngine;
using System.Collections;

public class CDeleteTutorialStage : MonoBehaviour {

    GameObject _tutorialStage;

    void Start()
    {
        _tutorialStage = GameObject.Find("TutorialStage");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player" && _tutorialStage != null)
        {
            Debug.Log("asdf");
            Destroy(_tutorialStage);
        }
    }
}
