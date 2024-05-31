using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanMover : MonoBehaviour
{
    public bool onStart;
    public Vector3 position;
    public float time;
    public LeanTweenType action;
    // Start is called before the first frame update
    void Start()
    {
        if(onStart)
        {
            Move();
        }    
    }

    public void Move()
    {
        LeanTween.move(this.gameObject, this.transform.position + position, time).setEase(action);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
