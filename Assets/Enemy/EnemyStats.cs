using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Actor
{
    public void Start()
    {
        this.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    override public void death(Vector2 dirHit)
    {
        this.GetComponent<Animator>().SetTrigger("dead");
        Destroy(this.gameObject,bloodLifetime);
        this.GetComponent<Rigidbody2D>().isKinematic = false;
        this.gameObject.layer = LayerMask.NameToLayer("Blood");
        this.GetComponent<Rigidbody2D>().AddForce(dirHit * bloodSpillForce, ForceMode2D.Impulse);
        return;
    }
}
