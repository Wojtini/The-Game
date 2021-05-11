using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 */
public class StuffContainer : MonoBehaviour
{
    public static StuffContainer instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}
