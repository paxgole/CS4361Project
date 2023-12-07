using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private float speed;
    public float zBound;

    // Start is called before the first frame update
    void Start()
    {
        speed = Globals.speed;
    }

    // Update is called once per frame
    void Update()
    {
        //public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta); 
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        //GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -speed));
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        
        if (transform.position.z < zBound)
        {
            Destroy(gameObject);
        }
    }

    //ToDo
    // 1) Rebuld wall to have hole. I am sure we can make a person shape if we wanted. -I am thinking three cubes snapped together - perhaps a few walls each with smaller and smaller holes. (i bet that could be scripted.)
    // 2) script what to do to when the wall and player collide (game over)
    // 3) scrite what happens when wall and target collide, (go to next level)
    // add texture? add music?
    // add cute voice bubbles that say things like "oh no!", "Panic!" and "Suck it in!"
    // adding simple but cute elements may mask how simple the game is. 
}
