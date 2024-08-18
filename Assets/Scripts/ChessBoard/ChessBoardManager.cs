using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardManager : MonoBehaviour
{
    public static ChessBoardManager Instance {  get; private set; }
    [SerializeField] private List<ChessBoardGrid> gridList;
    private void Awake()
    {
        Instance = this;
    }
}
