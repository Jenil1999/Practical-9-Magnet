using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetUpdown : MonoBehaviour
{
    public Rigidbody2D RB;
    public BoxCollider2D MgnBoxvara;
    public GameObject Mgn;

    public static MagnetUpdown Instance;

    public bool IsPressed = false;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        RB.isKinematic = false;
        RB.gravityScale = -15f;
        Mgn.SetActive(true);
        IsPressed = true;
    }
}
