using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Actor
{
    private Animator animator;
    private PlayerMovement playerMovement;

    public float max_inv = 2f;
    public float inv = 0f;

    private bool isDead = false;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        updateUI();
    }

    public void Update()
    {
        if (inv > 0)
        {
            inv = inv - Time.deltaTime;
        }
    }

    public override void takeDamage(int value, Vector2 dirHit)
    {
        if(inv <= 0)
        {
            base.takeDamage(value, dirHit);
            updateUI();
            inv = max_inv;
        }
    }

    override public void death(Vector2 dirHit)
    {
        if (isDead)
            return;
        isDead = true;
        playerMovement.SetFreezePlayerMovement(true);
        animator.SetTrigger("death");
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
