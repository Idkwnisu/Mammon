using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("TutorialDone"))
        {
            go.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
