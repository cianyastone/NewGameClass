﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int Blinks;
    public float time;

    private Renderer myRender;
    private ScreenFlash sf;
    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
        myRender = GetComponent<Renderer>();
        sf = GetComponent<ScreenFlash>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        sf.FlashScreen();
        health -= damage; 
        if(health < 0)
        {
            health = 0;
        }
        HealthBar.HealthCurrent = health;
        if(health <= 0)
        {
            rb2d.velocity = new Vector2(0, 0);
            rb2d.gravityScale = 0.0f;
            GameController.isGameAlive = false;
            Destroy(gameObject);
        }
        BlinkPlayer(Blinks, time);
    }

    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for(int i = 0;i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);

        }
        myRender.enabled = true;
    }
}
