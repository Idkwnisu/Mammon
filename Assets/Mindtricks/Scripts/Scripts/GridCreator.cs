using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public float x;
    public float y;
    public int gridSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGrid()
    {
        float xPos = 0;
        float yPos = 0;
        int c = 0;
        int fc = 0;
        int acc = 0;
        foreach (Transform g in transform.GetComponentsInChildren<Transform>())
        {
            if (g.gameObject.name != "CardSerie")
            {
                acc++;
             
                g.position = transform.position + new Vector3(xPos, yPos, fc * -0.01f);
                if(acc < 22)
                    xPos += x;
                c++;
                fc++;
                if (c >= gridSize && acc < 22)
                {
                    yPos += y;
                    xPos = 0;
                    c = 0;
                }
            }
        }
    }
}
