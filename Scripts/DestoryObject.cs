using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Map")
        {
            Destroy(this.gameObject);
        }
        
    }
}
