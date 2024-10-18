using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JetpackCollectable : MonoBehaviour
{
    [Header("Script References")]
    public PlayerControl PlayerControl;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // checks player collides with object
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerControl.AddFuel();
            // then the object is now destroyed
            Destroy(gameObject);
        }
    }
}
