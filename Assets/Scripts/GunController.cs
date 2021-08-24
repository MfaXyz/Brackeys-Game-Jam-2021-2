using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Vector3 _mousePoint;

    private void FixedUpdate()
    {
        PointAtMouse();
    }

    private void PointAtMouse()
    {
        _mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var thisTransform = transform.position;
        var direction = new Vector2(
            _mousePoint.x - thisTransform.x, _mousePoint.y - thisTransform.y);

        transform.up = direction;
    }
}
