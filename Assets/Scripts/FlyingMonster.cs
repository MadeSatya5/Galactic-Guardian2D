using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonster : Obstacle
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("TakeHit", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Panggil OnTriggerEnter2D dari base class
        base.OnTriggerEnter2D(collision);
    }
}
