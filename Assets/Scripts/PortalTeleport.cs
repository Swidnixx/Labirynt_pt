using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform linkedPortal;
    Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void FixedUpdate()
    {
        if(player != null)
        {
            Vector3 portalForward = transform.up;
            Vector3 portalToPlayer = player.position - transform.position;
            float dot = Vector3.Dot(portalForward, portalToPlayer);

            if(dot < 0)
            {
                player.position = linkedPortal.transform.position;
                player = null;
            }
        }
    }
}
