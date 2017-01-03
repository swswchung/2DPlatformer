using UnityEngine;
using System.Collections;

public class CLookRing : MonoBehaviour {

    public GameObject _ring;
    void Start()
    {
        StartCoroutine("ShotLookRing");
    }

    IEnumerator ShotLookRing()
    {
        int i = 0;
        while(i < 90)
        {
            //x축144~155
            //y축-48 ~ -50
            Instantiate(_ring,new Vector3(Random.Range(144f,155f),Random.Range(-48f,-50f),0f),Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            i++;
        }
        Destroy(gameObject);
    }
}
