using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Building1X2 : Building
{
    // POLYMORPHISM
    public override void MoveTo(Vector2 gridPosition, float hoverHeight)
    {
        Vector3 targetPosition = new Vector3(gridPosition.x, hoverHeight, gridPosition.y) +
                                 (transform.forward * transform.localScale.z / 4);
        transform.position = targetPosition;
    }
}