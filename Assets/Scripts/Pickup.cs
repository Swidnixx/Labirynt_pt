using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pick();
        }
    }

    protected virtual void Pick()
    {
        Destroy(gameObject);
    }
}
