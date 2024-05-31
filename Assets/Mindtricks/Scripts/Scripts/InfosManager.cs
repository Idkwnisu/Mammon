using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfosManager : MonoBehaviour
{
    public GameObject playingCardInfos;
    public Image cardImage;
    public Image cardOverlay;
    public TMP_Text description;

    public static InfosManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInfos(PlayingCard_Struct card)
    {
        cardImage.sprite = card.texture;
        description.text = card.hint;
        cardOverlay.color = card.color;
        playingCardInfos.SetActive(true);
    }

    public void CloseInfos()
    {
        playingCardInfos.SetActive(false);
    }
}
