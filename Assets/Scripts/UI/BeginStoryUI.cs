using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum t
{

}
public class BeginStoryUI : MonoBehaviour
{
    [SerializeField] private List<string> storys;
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private Button continueButton;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        int index = Random.Range(0, storys.Count);
        storyText.text = storys[index];
        continueButton.onClick.AddListener(() =>
        {
            animator.enabled = true;
            GameFlowStateManager.Instance.GoToState(GameFlowStateManager.Instance.beginState);
            gameObject.SetActive(false);
        });
    }
}
