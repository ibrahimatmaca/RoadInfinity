using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBlockScript : MonoBehaviour
{
    public Transform playerObject;
    private int destroyTile = 0;

    void Update()
    {
        transform.position = new Vector3(playerObject.position.x - 30f, 3f, 0);    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player")
        {
            GameController.instaniate.tileList.RemoveAt(destroyTile);
            Destroy(other.gameObject);
        }
    }

}
