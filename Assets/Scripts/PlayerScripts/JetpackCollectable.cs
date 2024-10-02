using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JetpackCollectable : MonoBehaviour
{
    [Header("Script References")]
    public PlayerControl PlayerControl;
    [Header("Fuel Variables")]
    public float FuelMaximum = 10000f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // checks player collides with object
        if (other.gameObject.CompareTag("Player"))
        {
            // jetpack active boolean is now true
            PlayerControl.JetpackFueled = true;
            // fuel amount is now the fuel maximum
            PlayerControl.FuelAmount = FuelMaximum;
            // then the object is now destroyed
            Destroy(gameObject);
        }
    }
}
