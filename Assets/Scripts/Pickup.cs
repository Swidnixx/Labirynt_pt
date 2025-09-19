using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public AudioClip sfx;

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
        SoundManager.Instance.PlaySFX(sfx);
    }
}
