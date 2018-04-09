using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotationAcorn : MonoBehaviour {

    public GameObject Acorn;
	
	void Update () {
        
          Acorn.transform.RotateAroundLocal(new Vector3(0,0,-1),Time.deltaTime*2f);
    }
}
