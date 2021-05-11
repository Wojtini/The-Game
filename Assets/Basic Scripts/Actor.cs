using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public GameObject blood;
    public float bloodSpillForce = 10f;
    public int amountOfBlood = 10;
    public float bloodLifetime = 5f;

    public int currentHealth = 5;
    public int maxHealth = 5;

    virtual public void takeDamage(int value, Vector2 dirHit)
    {
        currentHealth -= value;
        if (currentHealth < 0)
            currentHealth = 0;
        if (currentHealth == 0)
            death(dirHit);

        if (blood == null)
            return;

        for (int i = 0; i < amountOfBlood; i++)
        {
            GameObject pom = Instantiate(blood);
            pom.transform.position = this.transform.position;
            pom.transform.position = pom.transform.position + new Vector3(Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f), 0f);
            pom.GetComponent<Rigidbody2D>().AddForce(dirHit * bloodSpillForce, ForceMode2D.Impulse);
            if(StuffContainer.instance != null)
            {
                pom.transform.SetParent(StuffContainer.instance.transform);
            }
            Destroy(pom, bloodLifetime);
        }
    }

    virtual public void death(Vector2 dirHit)
    {
        Debug.Log("Death of undefined");
    }

    virtual public void healDamage(int value)
    {
        currentHealth += value;
        if (currentHealth < maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
