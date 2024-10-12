using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    [Header("Object References")]
    public GameObject BoomerangStillObject;
    public Rigidbody2D BoomerangMovingObject;
    public Transform PlayerPos;

    [Header("Boomerang Variables")]
    public float BoomerangRotSpeed = 10f;
    public float BoomeranFlySpeed = 100f;
    public bool InFlight;

    private void Start()
    {
        InFlight = false;
    }

    void Update()
    {
        BoomerangStillObject.SetActive(!InFlight);

        Vector3 AimPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = AimPoint - BoomerangStillObject.transform.position;

        float ObjRot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        BoomerangStillObject.transform.rotation = Quaternion.Euler(0, 0, ObjRot);

        if (Input.GetMouseButtonDown(0))
        {
            InFlight = true;
            BoomFlight();
        }
    }

    void BoomFlight()
    {
        Instantiate(BoomerangMovingObject, BoomerangStillObject.transform.position, Quaternion.identity);
    }
}
