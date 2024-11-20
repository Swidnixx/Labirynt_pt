using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanim : MonoBehaviour
{
    public Transform door;
    public Transform closedPos, openPos;

    public bool open;
    public float speed = 2;

    private void Update()
    {
        Vector3 targetPos = open ? openPos.position : closedPos.position;

        door.position = Vector3.MoveTowards(door.position, targetPos, Time.deltaTime * speed);
    }
}
