using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "SampleScene";



    // Start is called before the first frame update
    public void Start()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
