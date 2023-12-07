using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text scoretext;
    private float elapsed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Globals.endCondition)
        {
            elapsed += Time.deltaTime % 60;
            int showElapsed = (int)(elapsed);
            scoretext.text = "TIME: " + showElapsed.ToString() + " SECONDS";
        }
        else
        {
            Globals.score = elapsed;
        }
        
    }
}