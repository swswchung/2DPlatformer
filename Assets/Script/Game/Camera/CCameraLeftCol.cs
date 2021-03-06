﻿using UnityEngine;
using System.Collections;

public class CCameraLeftCol : CCamera {

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag.Equals("Player"))
        {
            if (col.transform.position.x < transform.position.x)
            {
                _mainCamera.position = new Vector3(_mainCamera.position.x - 12.5f, _mainCamera.position.y, _mainCamera.position.z);
            }
        }
        base.OnTriggerExit2D(col);
    }

}
