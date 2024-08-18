using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Button beginButton;
    [SerializeField] private Button setButton;
    [SerializeField] private Button endButton;
    [SerializeField] private Transform SetPanel;
    public AudioClip clip;
    private void Start()
    {
        beginButton.onClick.AddListener(() =>
        {
            ClipManager.Instance.PlayClip(clip);
            SceneManager.LoadScene(1);
        });
        setButton.onClick.AddListener(() =>
        {
            ClipManager.Instance.PlayClip(clip);
            SetPanel.gameObject.SetActive(true);
        });
        endButton.onClick.AddListener(() =>
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        });
    }
}
