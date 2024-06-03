using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroArea : MonoBehaviour
{
    public float time;
    public float delay;
    public float scale;


    public CanvasGroup[] extra;
    // Start is called before the first frame update
    void Start()
    {
        JuiceManager.Instance.ScaleJuice(this.GetComponent<CanvasGroup>(), time, delay, scale, End, UpdateExtra);
    }

    public void End()
    {
        gameObject.SetActive(false);
        for(int i = 0; i <extra.Length; i++)
        {
            extra[i].gameObject.SetActive(false);
        }
    }


    public void UpdateExtra(float value)
    {
        for (int i = 0; i < extra.Length; i++)
        {
            extra[i].alpha = 1 - value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
