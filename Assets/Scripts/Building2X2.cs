using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Building2X2 : Building
{
    // POLYMORPHISM
    public override void MoveTo(Vector2 gridPosition, float hoverHeight)
    {
        Vector3 scale = transform.localScale;
        Vector3 targetPosition =
            new Vector3(gridPosition.x + scale.x / 4, hoverHeight, gridPosition.y + scale.z / 4);
        transform.position = targetPosition;
    }
}