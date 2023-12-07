using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getLastScore : MonoBehaviour
{
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "Last Score :" + Globals.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
