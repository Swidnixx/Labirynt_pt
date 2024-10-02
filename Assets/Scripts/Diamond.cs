using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Pickup
{
    public int pointsToAdd = 1;

    protected override void Pick()
    {
        base.Pick();
        GameManager.Instance.points += pointsToAdd;
    }
}
