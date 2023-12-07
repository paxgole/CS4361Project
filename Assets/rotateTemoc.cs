using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTemoc : MonoBehaviour
{
    // public float rotas = 500f;
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     Vector3 newVec = new Vector3(0, rotas, rotas);
    //     transform.Rotate(newVec * Time.deltaTime);
    // }
    // Use this for initialization
	public float speed = 1;
	public float RotAngleY = 30;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		float rY = Mathf.SmoothStep(0,RotAngleY,Mathf.PingPong(Time.time * speed,1));
		transform.rotation = Quaternion.Euler(0,0,rY);
	}
}
