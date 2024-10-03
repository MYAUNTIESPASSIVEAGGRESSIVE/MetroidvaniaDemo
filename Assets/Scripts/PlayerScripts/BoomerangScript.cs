using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    [Header("References")]
    public GameObject SpinPos;

    void Start()
    {
        
    }

    void Update()
    {
        BoomFollow();

        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    private void BoomFollow()
    {
        Vector3 Mpos = Input.mousePosition;
        Mpos.z = 0;

        Vector3 Wpos = Camera.main.ScreenToWorldPoint(Mpos);
    }
}
