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

    public int Power
    {
        get
        {
            return power;
        }
        set
        {
            power = value;
            powerText.text = power.ToString();
        }
    }
    private int step;
    public int Step
    {
        get
        {
            return step;
        }
        set
        {
            step = value;
            stepText.text = step.ToString();
        }
    }

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
        Step = maxStep;
    }
    public void AddStep(int step)
    {
        Step += step;
    }
    public void AddPower()
    {
        Power += MapManager.Instance.Collection();
    }
    public int SubStep(int step)
    {
        Step -= step;
        return Step;
    }
    public void SubPower(int power)
    {
        Power -= power;
        // 消耗气事件
    }

    public void ClearPower()
    {
        Power = 0;
    }
}
