using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetUpdown1 : MonoBehaviour
{
    public Rigidbody2D RB;
    public GameObject Mgn1;

    public static MagnetUpdown1 Instance;

   public bool IsPressed = false;

    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        RB.isKinematic = false;
        RB.gravityScale = 15f;
        Mgn1.SetActive(true);
        IsPressed = true;
    }
}
