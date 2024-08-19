using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThanksUI : MonoBehaviour
{
    public Button backButton;
    public Button exitButton;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        backButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        gameObject.SetActive(false);
    }
    public void PlayAnimator()
    {
        animator.enabled = true;
    }
}
