using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHolder : MonoBehaviour
{

    public Cell Cell;
    [SerializeField] private int rows;
    [SerializeField] private int cols;
    private void Start()
    {
        GenerateGrid();
    }
    private void GenerateGrid()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Transform cell = Instantiate(Cell.transform);
                cell.SetParent(this.transform);
            }
        }
    }
}





