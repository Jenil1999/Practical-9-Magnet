using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effector : MonoBehaviour
{
    AreaEffector2D effector2D;
    public GameObject Magnet;

    private void Start()
    {
        effector2D = GetComponent<AreaEffector2D>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.CompareTag("Magnet") + "Magnet");
        Debug.Log(Magnet.GetComponent<SpriteRenderer>().color == Color.red);
        if (collision.gameObject.CompareTag("Magnet") && Magnet.GetComponent<SpriteRenderer>().color == Color.red)
        {
            //Debug.Log(Magnet.GetComponent<SpriteRenderer>().color);
            effector2D.forceMagnitude = 100;
        }
        else
        {
            effector2D.forceMagnitude = 00;
            Debug.Log("Else m aaya");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Magnet") && Magnet.GetComponent<SpriteRenderer>().color == Color.red)
        {
           // Debug.Log(Magnet.GetComponent<SpriteRenderer>().color);
            effector2D.forceMagnitude = 1000;
        }
        else
        {
            effector2D.forceMagnitude = 00;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Magnet") && Magnet.GetComponent<SpriteRenderer>().color == Color.red)
    //    {
    //        Debug.Log(Magnet.GetComponent<SpriteRenderer>().color);
    //        effector2D.forceMagnitude = 100;
    //    }
    //    else
    //    {
    //        effector2D.forceMagnitude = 0;
    //    }
    //}
}
