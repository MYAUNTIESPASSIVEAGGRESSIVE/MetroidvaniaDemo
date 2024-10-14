using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    [Header("Object References")]
    public Rigidbody2D BoomerangStillObject;
    public Transform PlayerPos;

    [Header("Boomerang Variables")]
    public float BoomerangRotSpeed = 10f;
    public float BoomerangFlySpeed = 10f;
    public bool InFlight;
    public float BoomDistanceMax = 10f;

    private void Start()
    {

    }

    void Update()
    {

        Vector3 AimPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = AimPoint - BoomerangStillObject.transform.position;

        float ObjRot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        BoomerangStillObject.transform.rotation = Quaternion.Euler(0, 0, ObjRot);

        if (Input.GetMouseButtonDown(0))
        {
            BoomerangStillObject.velocity = new Vector2(direction.x, direction.y).normalized * BoomerangFlySpeed;
        }
    }
}
