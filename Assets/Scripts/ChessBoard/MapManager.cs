using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject originCell;
    [SerializeField] private float padding;
    [SerializeField] private int row;
    [SerializeField] private int col;
    [SerializeField] private int cellW;
    private void Start()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                GameObject cloneCell = Instantiate(originCell);
                cloneCell.transform.SetParent(transform);
                cloneCell.transform.position = transform.position + Vector3.right * cellW * j + Vector3.forward * cellW * i
                    + Vector3.right * padding * j + Vector3.forward * padding * i;
            }
        }
    }
}
