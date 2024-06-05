using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public struct TutorialStep
{
    public GameObject[] toActivate;
}
public class TutorialManager : MonoBehaviour
{
    public TutorialStep[] steps;
    public int currentStep = 0;

    public UnityEvent endTutorial;
    // Start is called before the first frame update
    void Start()
    {
        GoToStep(0);
        PlayerPrefs.SetInt("TutorialDone", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToStep(int n)
    {
        for(int i = 0; i < steps[currentStep].toActivate.Length; i++)
        {
            steps[currentStep].toActivate[i].SetActive(false);
        }

        currentStep = n;

        for (int i = 0; i < steps[currentStep].toActivate.Length; i++)
        {
            steps[currentStep].toActivate[i].SetActive(true);
        }
    }

    public void GoToNextstep()
    {
        if (currentStep + 1 < steps.Length)
            GoToStep(currentStep +1);
        else
            endTutorial.Invoke();
    }
}
