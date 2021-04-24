using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Collider2D col;
    public Collider2D pogoCol;
    public Collider2D upCol;

    public GameObject sliceGFX;
    public float sliceDespawnTime = 0.1f;

    private float currAttackCooldown = 0f;
    public float attackCooldown = 1f;

    Animator animator;
    Rigidbody2D rb2d;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
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
            List<Collider2D> colList = new List<Collider2D>();
            bool wasPogoAttack = false;
            bool pogoAttackSuccess = false;
            GameObject slice;
            colList = new List<Collider2D>();
            int down = 1;
            if (Input.GetAxisRaw("Vertical") < -0.2)
            {
                animator.SetTrigger("PogoAttack");

                pogoCol.OverlapCollider(new ContactFilter2D(), colList);
                wasPogoAttack = true;
                // Slice effect
                slice = Instantiate(sliceGFX);
                //slice.transform.Rotate(new Vector3(0f,0f,-90f));
                down = -1;
            }
            else if (Input.GetAxisRaw("Vertical") > 0.2)
            {
                animator.SetTrigger("UpAttack");
                upCol.OverlapCollider(new ContactFilter2D(), colList);
                // Slice effect
                slice = Instantiate(sliceGFX);
                //slice.transform.Rotate(new Vector3(0f, 0f, 90f));
                down = 1;
            }
            else
            {
                animator.SetTrigger("Attack");
                col.OverlapCollider(new ContactFilter2D(),colList);
                //Spawn Slice gfx
                slice = Instantiate(sliceGFX);
                down = 0;
            }

            foreach (Collider2D col in colList)
            {
                if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    Vector3 dir = col.gameObject.transform.position - this.transform.position;
                    col.gameObject.GetComponent<Actor>().takeDamage(1, dir);
                    if (wasPogoAttack)
                        pogoAttackSuccess = true;
                }
            }
            if (pogoAttackSuccess)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);

                rb2d.AddForce(new Vector2(0f, this.GetComponent<PlayerMovement>().jumpForce));
            }

            slice.transform.position = this.transform.position;
            slice.transform.localScale = this.transform.localScale;
            slice.transform.parent = this.transform;

            slice.transform.Rotate(new Vector3(0f, 0f, 90f*down));

            Destroy(slice, sliceDespawnTime);
        }
    }
}
