using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public static MainUIHandler Instance;


    [SerializeField] private Dropdown dropdown;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Text messageText;
    private Coroutine _clearMessageCoroutine;
    private bool _isCoroutineRunning;

    public void OnBuildingChoiceChanged()
    {
        gameManager.SetBuildingChoice(dropdown.value);
    }

    public void ResetDropdown()
    {
        dropdown.value = 0;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        messageText.text = "";
        _isCoroutineRunning = false;
    }

    public void SetTempMessage(string message, int durationSeconds)
    {
        messageText.text = message;
        if (_isCoroutineRunning)
        {
            StopCoroutine(_clearMessageCoroutine);
        }

        _isCoroutineRunning = true;
        _clearMessageCoroutine = StartCoroutine(ClearMessage(durationSeconds));
    }

    IEnumerator ClearMessage(int durationSeconds)
    {
        yield return new WaitForSeconds(durationSeconds);
        messageText.text = "";
        _isCoroutineRunning = false;
    }
}