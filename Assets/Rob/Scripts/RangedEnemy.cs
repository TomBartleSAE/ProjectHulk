using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public float stopDistance;
    private float attackTime;
    private Animator anim;

    public Transform shotPoint;
    public GameObject enemyBullet;

    //private Rigidbody2D rb;

    private Vector2 position;


    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                //position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                //rb.MovePosition(position);
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                anim.SetFloat("Movement", 1);
            }

            else
            {
                if (Time.time >= attackTime)
                {
                    attackTime = Time.time + timeBetweenAttacks;
                    RangedAttack();
                }
                anim.SetFloat("Movement", 0);
            }
            
            if (player.position.x - transform.position.x > 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            }

            if (player.position.x - transform.position.x < 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            }
        }
    }

    public void RangedAttack()
    {
        Vector2 direction = player.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotPoint.rotation = rotation;
        anim.SetTrigger("Attack");

        Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);
    }

    private void OnEnable()
    {
        GetComponent<Health>().OnDamageEvent += Die;
    }

    private void OnDisable()
    {
        GetComponent<Health>().OnDamageEvent -= Die;
    }

    private void Die()
    {
        anim.SetTrigger("Die");
        Destroy(this);
        Destroy(gameObject, 5);
    }
}

