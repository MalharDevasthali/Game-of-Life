using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GridHolder : MonoBehaviour
{

    public Cell[] Cells;
    [SerializeField] private int rows = 6;
    [SerializeField] private int cols = 6;
    private int[,] array2D;

    private void Start()
    {
        array2D = new int[rows, cols];
        Populate2DArray();
    }
    private void Update()
    {
        SimulateGame();
    }
    private void Populate2DArray()
    {
        for (int i = 0; i < rows; i++)  //T(n) : O(n^2)
        {
            for (int j = 0; j < cols; j++)
            {
                array2D[i, j] = Random.Range(0, 2);
                Debug.Log("[" + i + "]" + "[" + j + "] ->" + array2D[i, j]);
            }
        }
    }
    private void SimulateGrid()
    {
        for (int i = 0; i < Cells.Length; i++) //T(n) : O(n)
        {
            Cells[i].SetCellValue(array2D[i / cols, i % cols]);
            Cells[i].SetColor();
        }
    }

    private void SimulateGame()
    {
        var next = new int[rows, cols];

        for (int i = 0; i < rows; i++)  //T(n) : O(n^2)
        {
            for (int j = 0; j < cols; j++)
            {
                int currentCell = array2D[i, j];
                int neighbours = CountNeighbours(array2D, i, j);


                if (currentCell == 0 && neighbours == 3)
                {
                    next[i, j] = 1;
                }
                else if (currentCell == 1 && (neighbours < 2 || neighbours > 3))
                {
                    next[i, j] = 0;
                }
                else
                {
                    next[i, j] = currentCell;
                }
            }
        }
        array2D = next;
        SimulateGrid();

    }
    private int CountNeighbours(int[,] grid, int x, int y)
    {
        int sum = 0;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int col = (x + i + cols) % cols;
                int row = (y + j + rows) % rows;
                sum += grid[col, row];
            }
        }
        sum -= array2D[x, y];
        return sum;
    }
}





