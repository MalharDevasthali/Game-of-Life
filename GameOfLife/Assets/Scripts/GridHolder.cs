using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHolder : MonoBehaviour
{

    public Cell[] Cells;
    private const int rows = 6;
    private const int cols = 6;
    private int[,] array2D = new int[rows, cols];
    private void Start()
    {
        PopulateVales();
    }

    private void PopulateVales()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i].SetCellValue(Random.Range(0, 2));
            Cells[i].SetColor();
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array2D[i, j] = Cells[(i * cols) + j].GetCellValue();
                Debug.Log("[" + i + "]" + "[" + j + "] ->" + Cells[(i * cols) + j].GetCellValue());
            }
        }
    }
}





