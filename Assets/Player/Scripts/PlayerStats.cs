using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Actor
{

    private void Start()
    {
        updateUI();
    }

    public override void takeDamage(int value, Vector2 dirHit)
    {
        base.takeDamage(value, dirHit);
        updateUI();
    }

    override public void death(Vector2 dirHit)
    {
        return;
    }

    override public void healDamage(int value)
    {
        base.healDamage(value);
        updateUI();
    }

    private void updateUI()
    {
        PlayerGUI.instance.hpUI.setMaxHealth(maxHealth); //To change, unecesetsfdsa
        PlayerGUI.instance.hpUI.setCurrentHealth(currentHealth);
    }
}
