using UnityEngine;
using System.Collections;

public class LookTarget : MonoBehaviour {

    public virtual void LookAt(Vector2 target)
    {
        float angle = AngleBeteweenPoints(transform.position, target);

        var targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 100f);
    }

    public float AngleBeteweenPoints(Vector2 option, Vector2 target)
    {
        return Mathf.Atan2(option.y - target.y, option.x - target.x) * Mathf.Rad2Deg;
    }
}
