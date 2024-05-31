using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanScaler : MonoBehaviour
{
    public bool onStart;
    public Vector3 scale;
    public float time;
    public LeanTweenType action;
    // Start is called before the first frame update
    void Start()
    {
        if (onStart)
        {
            Scale();
        }
    }

    public void Scale()
    {
        LeanTween.scale(this.gameObject, scale, time).setEase(action);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
