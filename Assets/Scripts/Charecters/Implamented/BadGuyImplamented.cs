using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyImplamented : AbstractCharecter
{
    private GameObject playerTag;
    protected Transform playerTransform;
    private void Start()
    {
        Initialize();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (playerTag == true)
        {
            moveTowardsPlayer();
        }
    }
    protected void Initialize()
    { 
        localScale = 1;
 
        // First we get the object with a player tag
        playerTag = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        // Then we get its movement 
        playerTransform = playerTag.transform;

    }

    private void moveTowardsPlayer()
    {
        
        if (playerTransform.transform.position.x > this.transform.position.x)
        {
            transform.Translate(Vector3.right * Time.deltaTime * currentSpeed);
            movement(direction = -1);

        }
        if(playerTransform.transform.position.x < this.transform.position.x)
        {
            transform.Translate(Vector3.left * Time.deltaTime * currentSpeed);
            movement(direction = 1);

        }
    }

    private void attackPlayer()
    {
        attack();
    }

    void OnCollisionEnter2D(Collision2D collision)
    { 
        
        if (collision.gameObject.tag == "Player")
        {
            attackPlayer();
        }
        if(collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Mouse0) == true)
        {
            health = health -20;
        }
        if(health == 0)
        {
            isDead();
            Destroy(this);
        }
    }
}
