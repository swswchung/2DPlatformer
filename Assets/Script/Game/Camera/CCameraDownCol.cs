using UnityEngine;
using System.Collections;

public class CCameraDownCol : CCamera {

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}

    protected override void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            if (col.transform.position.y < transform.position.y)
            {
                _mainCamera.position = new Vector3(_mainCamera.position.x, _mainCamera.position.y - 10f, _mainCamera.position.z);
            }
        }

        base.OnTriggerExit2D(col);
    }
}
