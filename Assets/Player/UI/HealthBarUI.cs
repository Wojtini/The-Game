using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject heartObject;

    public List<Image> hearts = new List<Image>();

    private void deleteAllHearts()
    {
        foreach(Image I in hearts)
        {
            Destroy(I.gameObject);
        }
        hearts = new List<Image>();
    }

    public void setMaxHealth(int value)
    {
        deleteAllHearts();
        for (int i = 0; i < value; i++)
        {
            GameObject a = Instantiate(heartObject);
            a.transform.SetParent(this.transform);
            Image img = a.GetComponent<Image>();
            a.GetComponent<Image>().sprite = emptyHeart;
            hearts.Add(img);
        }
    }

    public void setCurrentHealth(int value)
    {
        int i = 0;
        foreach (Image I in hearts)
        {
            if(i < value)
            {
                I.sprite = fullHeart;
            }
            else
            {
                I.sprite = emptyHeart;
            }
            i++;
        }
    }
}
