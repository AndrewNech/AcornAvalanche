using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapButton : MonoBehaviour {
    float x;
    float y;

    private void OnMouseDown()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;

        transform.localScale = new Vector3(transform.localScale.x-0.1f, transform.localScale.y - 0.1f, 1);
        transform.localRotation = Quaternion.Euler(0, 0, -5);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(x, y, 1);
        transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
