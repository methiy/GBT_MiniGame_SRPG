using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPlayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private Button backButton;

    private void Awake()
    {
        EventManager.Instance.AddListener(EventName.OnGameOverEvent, OnGameOver);
    }
    private void Start()
    {
        continueButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        returnButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        backButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
        continueButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnGameOver(object obj,EventArgs e)
    {
        gameObject.SetActive(true);
        var args = e as OnGameOverEventArgs;
        this.endText.text = "Loss";
        if (args.bIsWin)
        {
            continueButton.gameObject.SetActive(true);
            this.endText.text = "Win!";
        }
    }
}
