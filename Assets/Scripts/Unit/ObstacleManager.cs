using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance { get; private set; }
    [SerializeField] private List<Obstacle> obstacleList;
    [SerializeField] private List<Vector2> obstaclePosList;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        for(int i = 0;i < obstacleList.Count; i++)
        {
            Cell cell = MapManager.Instance.GetCellFromIndex(obstaclePosList[i]);
            obstacleList[i].SetCell(cell);
        }
        //foreach (var obstacle in obstacleList)
        //{
        //    Cell cell = MapManager.Instance.GetCellFromIndex(obstacle.Value);
        //    obstacle.Key.SetCell(cell);
        //}
    }
}
