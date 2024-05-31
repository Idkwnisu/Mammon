using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct TimedEvent
{
    public UnityEvent eventT;
    public float time;
    public bool fired;
}

public class Timer : MonoBehaviour
{
    public TimedEvent[] timedEvents;
    public bool allFired = false;
    public bool onStart;
    // Start is called before the first frame update
    void Start()
    {
        if(onStart)
            StartCoroutine(Elapse());
    }

    IEnumerator Elapse()
    {
        float t = 0;
        while(!allFired)
        {

            allFired = true;
            for(int i = 0; i < timedEvents.Length; i++)
            {
                if(!timedEvents[i].fired)
                {
                    if (t >= timedEvents[i].time)
                    {
                        timedEvents[i].eventT.Invoke();
                        timedEvents[i].fired = true;
                    }
                    else
                    {
                        allFired = false;
                    }
                }
            }
            t += 0.1f;
            yield return new WaitForSeconds(0.1f);

        }
    }

    public void FireAll()
    {
        for (int i = 0; i < timedEvents.Length; i++)
        {
            timedEvents[i].fired = false;
        }

        StartCoroutine(Elapse());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
