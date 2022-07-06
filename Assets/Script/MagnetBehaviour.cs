using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBehaviour : MonoBehaviour
{
    public GameObject MagnetDist;
    private GameObject GrabbedMagnet;
    public GameObject MagnetHolder;

    public float LaunchForce;


    private void Update()
    {
        float Distance = Vector2.Distance(transform.position, MagnetDist.transform.position);
        if(Distance < 2)
        {
            if (Input.GetKeyDown(KeyCode.E) && GrabbedMagnet == null)
            {
                GrabbedMagnet = MagnetDist;
                GrabbedMagnet.GetComponent<Rigidbody2D>().isKinematic = true;
                GrabbedMagnet.transform.position = MagnetHolder.transform.position;
                GrabbedMagnet.transform.SetParent(MagnetHolder.transform);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Fenko();
            }

        }
    }

    private void Fenko()
    {
        GrabbedMagnet.transform.SetParent(null);
        GrabbedMagnet.GetComponent<Rigidbody2D>().isKinematic = false;
        GrabbedMagnet.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        GrabbedMagnet = null;
    }
}


