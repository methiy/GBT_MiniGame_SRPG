using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanelUI : MonoBehaviour
{
    [SerializeField] private Slider bgmS;
    [SerializeField] private Slider soundS;
    [SerializeField] private Button closeButton;

    private void Start()
    {
        bgmS.value = SoundManager.Instance.GetVolume();
        bgmS.onValueChanged.AddListener((float value)=>
        {
            SoundManager.Instance.Volume(value);
        });

        soundS.value = ClipManager.Instance.audioSource.volume;
        soundS.onValueChanged.AddListener((float value) =>
        {
            ClipManager.Instance.audioSource.volume = value;
        });

        closeButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        gameObject.SetActive(false);
    }
}
