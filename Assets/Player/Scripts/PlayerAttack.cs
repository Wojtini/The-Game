using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Collider2D col;
    public Collider2D pogoCol;

    public GameObject sliceGFX;
    public float sliceDespawnTime = 0.1f;

    private float currAttackCooldown = 0f;
    public float attackCooldown = 1f;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(currAttackCooldown > 0f)
        {
            currAttackCooldown -= Time.deltaTime;
            return;
        }
        if (Input.GetButtonDown("Attack1"))
        {
            currAttackCooldown = attackCooldown;

            if (Input.GetAxisRaw("Vertical") < -0.2)
            {
                animator.SetTrigger("PogoAttack");
                List<Collider2D> colList = new List<Collider2D>();
                pogoCol.OverlapCollider(new ContactFilter2D(), colList);
                foreach (Collider2D col in colList)
                {
                    if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                    {
                        Vector3 dir = col.gameObject.transform.position - this.transform.position;
                        col.gameObject.GetComponent<Actor>().takeDamage(1, dir);

                        Rigidbody2D rb2d = this.GetComponent<Rigidbody2D>();

                        //reset x velocity, also prevents stacking up jump force when hit multiple enemies
                        rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);

                        rb2d.AddForce(new Vector2(0f, this.GetComponent<PlayerMovement>().jumpForce));
                    }
                }
                // Slice effect
                GameObject slice = Instantiate(sliceGFX);
                slice.transform.position = this.transform.position;
                slice.transform.localScale = this.transform.localScale;
                slice.transform.parent = this.transform;
                slice.transform.Rotate(new Vector3(0f,0f,-90f));
                Destroy(slice, sliceDespawnTime);
            }
            else
            {
                animator.SetTrigger("Attack");
                List<Collider2D> colList = new List<Collider2D>();
                col.OverlapCollider(new ContactFilter2D(),colList);
                foreach(Collider2D col in colList)
                {
                    if(col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                    {
                        Vector3 dir = col.gameObject.transform.position - this.transform.position;
                        col.gameObject.GetComponent<Actor>().takeDamage(1,dir);
                    }
                    Debug.Log(col);
                }
                //Spawn Slice gfx
                GameObject slice = Instantiate(sliceGFX);
                slice.transform.position = this.transform.position;
                slice.transform.localScale = this.transform.localScale;
                slice.transform.parent = this.transform;
                Destroy(slice, sliceDespawnTime);
            }
        }
    }
}
