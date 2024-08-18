using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProps : MonoBehaviour
{
    public static PlayerProps Instance {  get; private set; }
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI stepText;

    private int maxStep = 2;

    private int power;
    private int step;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        powerText.text = power.ToString();
        stepText.text = step.ToString();
    }

    public void RestStep()
    {
        step = maxStep;
        stepText.text = step.ToString();
    }
    public void AddStep(int step)
    {
        this.step += step;
        stepText.text = this.step.ToString();
    }
    public void AddPower()
    {
        this.power += MapManager.Instance.Collection();
        powerText.text = this.power.ToString();
    }
    public int SubStep(int step)
    {
        this.step -= step;
        stepText.text = this.step.ToString();
        return this.step;
    }
    public void SubPower(int power)
    {
        this.power -= power;
        powerText.text= this.power.ToString();
        // 消耗气事件
    }
}
