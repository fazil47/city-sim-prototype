using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    [SerializeField] private Building[] buildingPrefabs;
    [SerializeField] private float hoverHeight = 2f;
    [SerializeField] private MainUIHandler mainUIHandler;

    private Building _currentBuildingChoice;

    public void SetBuildingChoice(int choice)
    {
        if (choice <= buildingPrefabs.Length && choice > 0)
        {
            MainUIHandler.Instance.SetTempMessage("Right mouse button to rotate and Q to stop placing building.", 3);
            Building buildingPrefab = buildingPrefabs[choice - 1];
            Vector3 spawnPosition =
                new Vector3(gridManager.MouseOverGridPosition.x, hoverHeight, gridManager.MouseOverGridPosition.y);
            _currentBuildingChoice = Instantiate(buildingPrefab, spawnPosition,
                buildingPrefab.transform.rotation);
        }
    }

    private void StopPlacingBuilding()
    {
        Destroy(_currentBuildingChoice.gameObject);
        _currentBuildingChoice = null;
        mainUIHandler.ResetDropdown();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (_currentBuildingChoice == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StopPlacingBuilding();
            return;
        }

        // ABSTRACTION
        Vector2 gridPosition = gridManager.MouseOverGridPosition;

        // ABSTRACTION
        _currentBuildingChoice.MoveTo(gridPosition, hoverHeight);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _currentBuildingChoice.Rotate();
        }

        // ABSTRACTION
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_currentBuildingChoice.IsPositionValid())
            {
                _currentBuildingChoice.Place();
                mainUIHandler.ResetDropdown();
                _currentBuildingChoice = null;
            }
            else
            {
                MainUIHandler.Instance.SetTempMessage("Can't place building there.", 4);
            }
        }
    }
}