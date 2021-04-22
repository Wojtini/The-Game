using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    public static PlayerGUI instance;
    public HealthBarUI hpUI;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        hpUI = GetComponentInChildren<HealthBarUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
