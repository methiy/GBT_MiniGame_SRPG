using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Color highColor;
    private Material selfMaterial;
    private Color originColor;

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
}
