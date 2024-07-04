using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSounder : MonoBehaviour
{
    public AudioClip defaultClip;
    private AudioSource audioSource;
    public Button[] buttons;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(PlayDefaultSound);
        }
    }

    public void PlayDefaultSound()
    {
        audioSource.PlayOneShot(defaultClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
