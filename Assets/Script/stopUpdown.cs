using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopUpdown : MonoBehaviour
{
    public GameObject UpDownMagnet;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            UpDownMagnet.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
