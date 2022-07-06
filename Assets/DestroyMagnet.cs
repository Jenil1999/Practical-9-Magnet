using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMagnet : MonoBehaviour
{
    public GameObject Magnet;
    public GameObject SpawnPoint;

    private void Start()
    {
        SpawnPoint = Instantiate(Magnet,SpawnPoint.transform.position, SpawnPoint.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Magnet"))
        {
            Destroy(Magnet);

           //SpawnPoint = Instantiate(Magnet,SpawnPoint.transform.position,SpawnPoint.transform.rotation);
        }
    }
}
