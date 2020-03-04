using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheFloor : MonoBehaviour
{
    public LayerMask targetLayer;
    private bool objectOnTheFloor = false;
    private bool buttonOnDown = false;

    public Rigidbody2D physicPlayer;
    [SerializeField]
    private float jumpPower = 0;

    private void Update()
    {
        RaycastControl();
        if (buttonOnDown && objectOnTheFloor)
        {
            physicPlayer.velocity += new Vector2(0, jumpPower);
        }
    }

    //Player is on the floor? Control !
    private void RaycastControl()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, targetLayer);
        
        if (hit.collider != null)
        {
            objectOnTheFloor = true;
            physicPlayer.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }
        else
        {
            objectOnTheFloor = false;
            physicPlayer.GetComponent<Rigidbody2D>().gravityScale = 0.7f;
        }
    }

    public void JumpButtonDown()
    {
        buttonOnDown = true;
    }

    public void JumpButtonUp()
    {
        buttonOnDown = false;
    }

}
