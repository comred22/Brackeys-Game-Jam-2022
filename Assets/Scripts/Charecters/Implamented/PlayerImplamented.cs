using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerImplamented : AbstractCharecter
{
    // Update is called once per frame

    // Sounds made by samurai
    [SerializeField] private AudioClip[] grunts;
    [SerializeField] private AudioClip[] hidaTalking;
    [SerializeField] private AudioClip[] deathsound;
    private float volumeScale = 1.0f;

    // In game time
    private float secoundsInGame;
   
    // Switch between 
    private int randomNum;
    void Update()
    {
        randomNum = Random.Range(0, 1);


        if (Input.GetKey(KeyCode.Space))
        {
            this.jump();
            this.Fall();
            audioSource.PlayOneShot(RandomClip(grunts));
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

        secoundsInGame -= Time.deltaTime;
        if (secoundsInGame < 10.0f)
        {
            
            voiceLines();
            secoundsInGame = 60.0f;
        }

    }
    private void Start()
    {
        localScale = 1;
        secoundsInGame = 80.0f;
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

            audioSource.PlayOneShot(RandomClip(deathsound));
            SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
        }
    }
    private void voiceLines()
    {
        audioSource.PlayOneShot(RandomClip(hidaTalking));
    }
}
