using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConstraints : MonoBehaviour
{
    public static LevelConstraints instance;
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;

    //bad but does the job for now
    public float camHeight = 5.6f;
    public float camWidth = 10f;
    void Awake()
    {
        instance = this;
    }
    //zmienic na zmienne i metody do zmieniania punktu ograniczenia
    public float getLeftConstraint()
    {
        return left.transform.position.x + camWidth;
    }
    public float getRightConstraint()
    {
        return right.transform.position.x - camWidth;
    }
    public float getUpConstraint()
    {
        return up.transform.position.y - camHeight;
    }
    public float getDownConstraint()
    {
        return down.transform.position.y + camHeight;
    }
}
