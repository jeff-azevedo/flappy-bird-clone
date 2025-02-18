using System;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public float flapStrength;
    public LogicScript logic;
    public bool isBirdDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        flapStrength = 5;
        isBirdDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isBirdDead)
        {
            Debug.Log(isBirdDead);
            myRigidbody2D.linearVelocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 16 || transform.position.y < -16)
            logic.gameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isBirdDead = true;
        logic.gameOver();
    }
}
