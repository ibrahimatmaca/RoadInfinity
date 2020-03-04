using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndWallScriptPack : MonoBehaviour
{
    private Vector3[] createPositions = new Vector3[2];
    public int starYdivision;
    public int wallYdivision;

    public GameObject[] objectCreate;
    private Sprite objectRandomSprite;

    private void Start()
    {
        objectRandomSprite = transform.GetComponent<SpriteRenderer>().sprite;
        
        createPositions[0] = new Vector3(transform.position.x - 5f, transform.position.y + (objectRandomSprite.bounds.size.y / starYdivision), 0);
        createPositions[1] = new Vector3(transform.position.x + 3.5f, transform.position.y + (objectRandomSprite.bounds.size.y / wallYdivision), 0);
        ObjectCreateFunction();
    }

    //Create random object Tile1 object
    private void ObjectCreateFunction()
    {
        for(int i = 0; i < 2; i++)
        {
            int randomOb = Random.Range(0, 2);

            Instantiate(objectCreate[randomOb], createPositions[i], Quaternion.identity, transform);
        }
    }
}
