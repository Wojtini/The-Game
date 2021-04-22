using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject blood;
    public float bloodSpillForce = 10f;
    public int amountOfBlood = 10;
    public float bloodLifetime = 5f;

    public int currentHealth = 5;
    public int maxHealth = 5;

    private void Start()
    {
        updateUI();
    }

    public void takeDamage(int value,Vector2 dirHit)
    {
        currentHealth -= value;
        if (currentHealth < 0)
            currentHealth = 0;
        if (currentHealth == 0)
            death();
        updateUI();

        for(int i = 0; i < amountOfBlood; i++)
        {
            GameObject pom = Instantiate(blood);
            pom.transform.position = this.transform.position;
            pom.transform.position = pom.transform.position + new Vector3(Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f), 0f);
            pom.GetComponent<Rigidbody2D>().AddForce(dirHit* bloodSpillForce, ForceMode2D.Impulse);
            Destroy(pom, bloodLifetime);
        }
    }

    private void death()
    {

    }

    public void healDamage(int value)
    {
        currentHealth += value;
        if(currentHealth < maxHealth)
        {
            currentHealth = maxHealth;
        }
        updateUI();
    }

    private void updateUI()
    {
        PlayerGUI.instance.hpUI.setMaxHealth(maxHealth); //To change, unecesetsfdsa
        PlayerGUI.instance.hpUI.setCurrentHealth(currentHealth);
    }
}
