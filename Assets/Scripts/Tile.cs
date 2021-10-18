using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied;
    // public Tuple<int, int> Position;

    private GridManager _gridManager;

    // public void Initialize(int i, int j)
    // {
    //     Position = new Tuple<int, int>(i, j);
    // }

    private void Start()
    {
        isOccupied = false;
        _gridManager = GetComponentInParent<GridManager>();
    }

    private void OnMouseEnter()
    {
        Vector3 tilePosition = transform.position;
        if (_gridManager)
        {
            _gridManager.SetMouseOverGridPosition(new Vector2(tilePosition.x, tilePosition.z));
        }
    }
}