using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    public float speed = 0.5f;
	public float RotAngleY = 3;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		float rY = Mathf.SmoothStep(-RotAngleY,RotAngleY,Mathf.PingPong(Time.time * speed,1));
		transform.rotation = Quaternion.Euler(0,0,rY);
	}
}
