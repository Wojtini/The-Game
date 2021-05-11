using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    public static PlayerGUI instance;
    public HealthBarUI hpUI;

    public TextPrompt textPrompt;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        hpUI = GetComponentInChildren<HealthBarUI>();
    }

    public void ShowTextPrompt(string primaryText, string secondaryText, float lifeTime)
    {
        textPrompt.DisplayTexts(primaryText,secondaryText,lifeTime);
    }
    
}
