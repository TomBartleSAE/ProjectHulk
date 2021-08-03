using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    public int health;

    private Vector2 moveAmount;
    



    // Start is called before the first frame update
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveAmount = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

 
    
}

