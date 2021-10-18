using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFloor : MonoBehaviour
{
    [Tooltip("Number of tiles per side")] [SerializeField]
    private int sideLength = 10;

    [SerializeField] private GameObject tilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 tilePrefabScale = tilePrefab.transform.localScale;
        float xOffset = tilePrefabScale.x / 2;
        float zOffset = tilePrefabScale.z / 2;

        for (int i = -sideLength / 2; i < sideLength / 2; i++)
        {
            for (int j = -sideLength / 2; j < sideLength / 2; j++)
            {
                Vector3 parentPosition = transform.position;
                Vector3 position = new Vector3(parentPosition.x + i + xOffset, parentPosition.y,
                    parentPosition.z + j + zOffset);
                Instantiate(tilePrefab, position, tilePrefab.transform.rotation, transform);
            }
        }
    }
}