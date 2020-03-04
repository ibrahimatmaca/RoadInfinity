using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int spriteIndex;
    private float speed = 0;
   
    private bool playerIsTouch = false;

    private Rigidbody2D physic;
    public Sprite[] spriteArrayBallGame;

    private void Start()
    {
        physic = transform.GetComponent<Rigidbody2D>();
        spriteIndex = PlayerPrefs.GetInt("Ball");
        transform.GetComponent<SpriteRenderer>().sprite = spriteArrayBallGame[spriteIndex];
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerGameOver();
    }

    //Object Movemment
    private void PlayerMovement()
    {
        if (speed > 0 && playerIsTouch)
        {
            physic.AddForce(transform.right * speed);
        }
        else
        {
            playerIsTouch = false;
        }
    }

    public void PlayerSpeedGas()
    {
        playerIsTouch = true;
        if(GameController.instaniate.meterFloatScore < 75)
        {
            speed = 3.5f;
        }
        else
        {
            speed = 5.5f;
        }
    }

    public void PlayerSpeedNotGas()
    {
        speed = 0;
        playerIsTouch = false;
    }

    private void PlayerGameOver()
    {
        if(transform.position.y < -5f)
        {
            GameController.instaniate.playerIsDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Star")
        {
            GameController.instaniate.coin++;
            Destroy(collision.gameObject);
        }
    }

}
