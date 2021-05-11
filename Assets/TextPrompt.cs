using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrompt : MonoBehaviour
{
    public Text primaryText;
    public Text secondaryText;

    public float lifetime = 0f;

    void Update()
    {
        if(lifetime < 0)
        {
            primaryText.text = "";
            secondaryText.text = "";
        }
        else
        {
            lifetime -= Time.deltaTime;
        }
    }

    public void DisplayTexts(string p, string s, float lifetime)
    {
        primaryText.text = p;
        secondaryText.text = s;
        this.lifetime = lifetime;
    }
}
