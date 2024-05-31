using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SequenceHandler : MonoBehaviour
{
    public TMP_Text sequenceValue;
    public int CheckHand(PlayingCard_Struct[] cards)
    {
        int acc = 0;
        for(int i = 0; i < cards.Length; i++)
        {
            acc += cards[i].value;
        }
        if (acc > 21)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                acc -= cards[i].value;
                acc += cards[i].altValue;
                if(acc <= 21)
                {
                    i = cards.Length;
                }
            }

        }
        sequenceValue.text = acc.ToString();
        if (acc <= 21)
        {
            if(acc == 21)
            {
                return 1;
            }
            return 0;
        }
        else
        {
            return -1;
        }
    }

    public void ResetText()
    {
        sequenceValue.text = "0";
    }
}
