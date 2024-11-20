using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public DoorMechanim[] doors;
    public KeyColor properKey;

    bool playerInRange;
    bool alreadyUnlocked;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (alreadyUnlocked) return; 

        if(playerInRange && GameManager.Instance.HasKey(properKey))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Unlock(); 
            }
        }
    }

    void Unlock()
    {
        animator.SetTrigger("open");

        alreadyUnlocked = true;

        foreach (var d in doors)
        {
            d.open = true; 
        }

        GameManager.Instance.UseKey(properKey);
    }
}
