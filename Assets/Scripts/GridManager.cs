using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Public Fields

    // ENCAPSULATION
    public Vector2 MouseOverGridPosition
    {
        get { return _mouseOverGridPosition; }
    }

    #endregion


    #region Private Fields

    [Tooltip("Number of tiles per side")] [SerializeField]
    private int sideLength = 10;

    [SerializeField] private GameObject tilePrefab;

    private Vector2 _mouseOverGridPosition;

    #endregion


    #region Public Methods

    public void SetMouseOverGridPosition(Tile tile)
    {
        Vector3 tilePosition = tile.transform.position;
        _mouseOverGridPosition = new Vector2(tilePosition.x, tilePosition.z);
    }

    #endregion

    #region Private Methods

    // Start is called before the first frame update
    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        Vector3 tilePrefabScale = tilePrefab.transform.localScale;
        float xOffset = tilePrefabScale.x / 2;
        float zOffset = tilePrefabScale.z / 2;

        for (int i = 0; i < sideLength; i++)
        {
            for (int j = 0; j < sideLength; j++)
            {
                Vector3 parentPosition = transform.position;
                Vector3 position = new Vector3(parentPosition.x + (i - sideLength / 2) + xOffset, parentPosition.y,
                    parentPosition.z + (j - sideLength / 2) + zOffset);
                Instantiate(tilePrefab, position, tilePrefab.transform.rotation, transform)
                    .GetComponent<Tile>();
            }
        }
    }

    #endregion
}