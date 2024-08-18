using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPropsTemplateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI hpMaxText;
    [SerializeField] private Image hpImage;
    private Enemy enemy;
    private void Start()
    {
        EventManager.Instance.AddListener(EventName.OnEnemyHPChangedEvent, OnEnemyHPChanged);
    }
    public void Init(Enemy enemy)
    {
        this.enemy = enemy;
        hpText.text = enemy.HP.ToString();
        hpMaxText.text = enemy.HP.ToString();
    }

    private void OnEnemyHPChanged(object obj,EventArgs e)
    {
        if(obj as Enemy == enemy)
        {
            print("是我变了" + enemy.name);
            hpText.text = enemy.HP.ToString();
            hpMaxText.text = enemy.HP.ToString();
            hpImage.fillAmount = enemy.HP / enemy.maxHp;
        }
    }
}
