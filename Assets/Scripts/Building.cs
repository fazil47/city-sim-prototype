using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [SerializeField] private float maxRaycastDistance = 100f;
    [SerializeField] private Transform[] raycastOrigins;

    public virtual void MoveTo(Vector2 gridPosition, float hoverHeight)
    {
        Vector3 targetPosition =
            new Vector3(gridPosition.x, hoverHeight, gridPosition.y);
        transform.position = targetPosition;
    }

    public virtual void Place()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition =
            new Vector3(currentPosition.x, transform.localScale.y / 2, currentPosition.z);
        transform.position = targetPosition;
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, 90f);
    }

    public bool IsPositionValid()
    {
        bool isTileBelowEmpty = true;

        foreach (Transform origin in raycastOrigins)
        {
            isTileBelowEmpty = isTileBelowEmpty && IsTileBelowEmpty(origin.position);
        }

        return isTileBelowEmpty;
    }

    private bool IsTileBelowEmpty(Vector3 origin)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin, Vector3.down, out hit, maxRaycastDistance))
        {
            if (hit.collider.gameObject.CompareTag("Tile"))
            {
                Debug.DrawRay(origin, Vector3.down * hit.distance, Color.green);
                return true;
            }
        }

        Debug.DrawRay(origin, Vector3.down * hit.distance, Color.red);
        return false;
    }
}