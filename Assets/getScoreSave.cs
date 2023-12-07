using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getLastScoreSave : MonoBehaviour
{
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "My Score : " + Globals.score.ToString() + " Seconds lasted on my pilgrimage!";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
