using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public static LevelInfo instance;
    public Sprite levelBackground;

    void Awake()
    {
        instance = this;
    }
}
