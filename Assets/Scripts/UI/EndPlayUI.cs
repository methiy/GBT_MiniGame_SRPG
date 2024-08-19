using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPlayUI : MonoBehaviour
{
    [SerializeField] private List<string> storyList;
    [SerializeField] private Image lossImage;
    [SerializeField] private Image winImage;
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private Button backButton;
    public ThanksUI thanksUI;
    public AudioClip clip;
    private void Awake()
    {
        EventManager.Instance.AddListener(EventName.OnGameOverEvent, OnGameOver);
    }
    private void Start()
    {
        continueButton.onClick.AddListener(() =>
        {
            EventManager.Instance.Clear();
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) 
            {
                thanksUI.gameObject.SetActive(true);
                SoundManager.Instance.audioSource.clip = clip;
                SoundManager.Instance.audioSource.Play();
                thanksUI.PlayAnimator();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        });
        returnButton.onClick.AddListener(() =>
        {
            EventManager.Instance.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        backButton.onClick.AddListener(() =>
        {
            EventManager.Instance.Clear();
            SceneManager.LoadScene(0);
        });
        int index = UnityEngine.Random.Range(0, storyList.Count);
        storyText.text = storyList[index];
        continueButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnGameOver(object obj,EventArgs e)
    {
        gameObject.SetActive(true);
        var args = e as OnGameOverEventArgs;
        //this.endText.text = "Loss";
        if (args.bIsWin)
        {
            lossImage.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(true);
            //this.endText.text = "Win!";
        }
        else
        {
            winImage.gameObject.SetActive(false);
        }
    }
}
