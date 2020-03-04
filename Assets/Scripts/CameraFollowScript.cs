using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{

    public Transform followObject;
    //kamera objemizi takip etmesi için yazmamız gerekn kod
    void Update()
    {
        transform.position = new Vector3(followObject.position.x, transform.position.y, transform.position.z);
    }
}
