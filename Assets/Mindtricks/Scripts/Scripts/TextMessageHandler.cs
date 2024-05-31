using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMessageHandler : MonoBehaviour
{
    public TMP_Text label;

    public void ShowText(string text)
    {
        label.text = text;
    }

    public void Over21()
    {
        label.text = "Busted";
    }

    public void Lost()
    {
        label.text = "You died in the catacombs";
    }    
	
	public void Card()
	{
		label.text = "Draw a new Card if you dare!";
	}
	
}
