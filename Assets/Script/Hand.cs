using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float Force;

    public Vector2 Direction;
    public GameObject pointPrefab;

    public GameObject[] Points;

    public int NumberOfPoints;

    public Transform PointStartPos;

    public float SpaceBetnTwoPoints;

    public GameObject MagnetDist;
    private GameObject GrabbedMagnet;
    bool Activated = false;//YouCanChangeColor

    

    private void Update()
    {
        float Distance = Vector2.Distance(transform.position, MagnetDist.transform.position);
        if (Distance < 2)
        {
            if (Input.GetKeyDown(KeyCode.E) && GrabbedMagnet == null)
            {
                GrabbedMagnet = MagnetDist;
                GrabbedMagnet.GetComponent<Rigidbody2D>().isKinematic = true;
                GrabbedMagnet.transform.position = transform.position;
                GrabbedMagnet.transform.SetParent(transform);

                Points = new GameObject[NumberOfPoints];

                Activated = true;

                for (int i = 0; i < NumberOfPoints; i++)
                {
                    Points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
                }

            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Fenko();

                Points = new GameObject[0];
                DestroyPrefabsInScene("Dot");
            }  

        }
        if (Activated == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && MagnetDist.GetComponent<SpriteRenderer>().color == Color.red)
            {
                MagnetDist.GetComponent<SpriteRenderer>().color = Color.blue;
            }

            else if (Input.GetKeyDown(KeyCode.F))
            {
                MagnetDist.GetComponent<SpriteRenderer>().color = Color.red;
            }

        }

        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 HolderPos = transform.position;

        Direction = MousePos - HolderPos;

        FaceCamera();


        for (int i = 0; i < Points.Length; i++)
        {
            Points[i].transform.position = PointPosition(i * SpaceBetnTwoPoints);
        }
    }


    private void Fenko()
    {
        GrabbedMagnet.transform.SetParent(null);
        GrabbedMagnet.GetComponent<Rigidbody2D>().isKinematic = false;
        GrabbedMagnet.GetComponent<Rigidbody2D>().velocity = transform.right * Force;
        GrabbedMagnet = null;
    }

    void DestroyPrefabsInScene(string tagName)
    {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag(tagName);
        foreach (GameObject prefab in prefabs)
        {
            Destroy(prefab);
        }
    }

    void FaceCamera()
    {
        transform.right = Direction;

        
    }

    Vector2 PointPosition(float t)
    {
        Vector2 CurrentPos = (Vector2)PointStartPos.position + (Direction.normalized * Force * t) + 0.5f * Physics2D.gravity * (t * t);

        return CurrentPos;
    }
}


