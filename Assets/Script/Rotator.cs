using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject Magnet;
    public AnimationClip Red90;
    public AnimationClip Blue90;
    Animation anim;
    public AreaEffector2D effector2D;

    private void Start()
    {
        anim = GetComponent<Animation>();
        //effector2D = GetComponent<AreaEffector2D>();
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.CompareTag("Magnet") + "Magnet");
        Debug.Log(Magnet.GetComponent<SpriteRenderer>().color == Color.red);
        if (collision.gameObject.CompareTag("Magnet") && Magnet.GetComponent<SpriteRenderer>().color == Color.red)
        {
            anim.clip = Red90;
            anim.Play();
            effector2D.forceMagnitude = 100;
        }

        else if (collision.gameObject.CompareTag("Magnet") && Magnet.GetComponent<SpriteRenderer>().color == Color.blue)
        {
            anim.clip = Blue90;
            anim.Play();
            effector2D.forceMagnitude = 00;
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Magnet") && Magnet.GetComponent<SpriteRenderer>().color == Color.red)
    //    {
    //        anim.clip = Red90;
    //        anim.Play();

    //    }

    //    else if (collision.gameObject.CompareTag("Magnet") && Magnet.GetComponent<SpriteRenderer>().color == Color.blue)
    //    {
    //        anim.clip = Blue90;
    //        anim.Play();
    //    }
    //}
}
