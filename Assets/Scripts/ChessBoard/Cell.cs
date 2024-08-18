using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Color highColor;
    [SerializeField] private Color selectColor;
    private Material selfMaterial;
    private Color originColor;
    public bool bCanSelect = true;
    public int x;
    public int y;

    private void Start()
    {
        selfMaterial = GetComponent<MeshRenderer>().material;
        originColor = selfMaterial.color;
    }
    public void High()
    {
        selfMaterial.color = highColor;
    }
    public void Normal()
    {
        selfMaterial.color = originColor;
    }
    public void PreSelect()
    {
        selfMaterial.color = selectColor;
    }
    public void UnSelect()
    {
        selfMaterial.color = highColor;
    }
}
