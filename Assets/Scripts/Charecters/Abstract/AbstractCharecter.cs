using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is the abstract charecter class
/// 
/// It has animation for any model
/// 
/// as well as attack and movements
/// 
/// https://docs.unity3d.com/Manual/AnimationOverview.html For info on animations
/// </summary>

/// <SoundKey>
/// This is the key for The sounds in the array 
/// </SoundKey>


public abstract class AbstractCharecter : MonoBehaviour
{
    public GameObject sprite;
    protected int direction;
    [SerializeField] protected Animator anim;
    public float currentSpeed;
    // Sounds 
    public AudioClip [] attackSounds;
    public AudioClip[] walkingSounds;
    public AudioClip[] SpeechSounds;
    // 2D Detection 
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxCollider;
    public Rigidbody2D rb;
    protected int localScale;
    // Jumping
    public float jumpVelocity;

    // Health and attack
    [SerializeField]public int health;
    protected float damageDealt;
    protected float attackRate;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void attack()
    {
        anim.SetTrigger("Attack");
        if (walkingSounds.Length < 0)
        {
            AudioSource.PlayClipAtPoint(this.attackSounds[0], this.transform.position);
        }
    }
    public void movement(int direction)
    {
        anim.SetFloat("Speed", 0.5f);
        Vector3 charecterScale = transform.localScale;
        if (direction < 0)
        {
            charecterScale.x = -this.localScale; 
        }
        if(direction > 0)
        {
            charecterScale.x = this.localScale;
        }
        transform.localScale = charecterScale;
        if (walkingSounds.Length < 0)
        {
            AudioSource.PlayClipAtPoint(this.walkingSounds[0], this.transform.position);
        }
        
    }
    public void jump()
    {
        anim.SetTrigger("Jump");
        Fall();
    }
    protected void Fall()
    {
        anim.SetTrigger("Fall");
    }
    protected void isDead()
    {
        anim.SetTrigger("IsDead");
    }
    protected void hitTake()
    {
        anim.SetTrigger("IsHurt");
    }
}
