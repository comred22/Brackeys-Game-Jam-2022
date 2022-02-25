using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerImplamented : AbstractCharecter
{
    public GUIStyle samurai;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            this.jump();
            transform.Translate(Vector3.up * Time.deltaTime * jumpVelocity);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * currentSpeed);
            this.direction = 1;
            this.movement(direction);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.right * Time.deltaTime * currentSpeed);
            this.direction = -1;
            this.movement(direction);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            this.attack();
        }
        if (!Input.anyKey)
        {
            anim.SetFloat("Speed", 0.0f);
        }
        if (health == 0)
        {
            isDead();
        }

    }
    private void Start()
    {
        localScale = 1;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" )
        {
            hitTake();
            health = health - 10;
        }
        if(health == 0)
        {
            // Play Death animation, then retutn to main menu.
            isDead();
            SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
        }
    }


}
