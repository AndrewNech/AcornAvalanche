using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public GameObject Destroyer;

    private void OnCollisionEnter2D(Collision2D collision)
    {  
        Destroy(collision.gameObject);
    }
    private void Update()
    {
        Destroyer.transform.position = new Vector3(0, -6.16f, -3);
        Destroyer.transform.rotation = new Quaternion(0, 0, 0,0);
    }


}
