using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth;
    private bool isFacingRight = true;

    private float horizontalInput;
    private float moveSpeed = 6f;

    private Rigidbody2D _rigidbody;

    private Animator _animator;

    [SerializeField] private Slider slideHealth;

    public bool startGame = false;

    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slideHealth.value = maxHealth;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = joystick.Horizontal;
        // if the player is moving activate animation of slide
        
        if (_rigidbody.velocity.x > 0f || _rigidbody.velocity.x < 0f)
        {
            _animator.SetBool("moving",true);
        }
        else
        {
            _animator.SetBool("moving",false); 
        }
        Flip();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(horizontalInput * moveSpeed, _rigidbody.velocity.y);
    }

    public void Flip()
    {
        if(isFacingRight && horizontalInput <0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void HealthManagement(int amount)
    {
        health -= amount;
        slideHealth.value = health;
        
        if (health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(gameObject);
        Application.Quit();
    }
}
