using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GridHolder : MonoBehaviour
{

    public Cell[] Cells;
    [SerializeField] private int rows;
    [SerializeField] private int cols;
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


    /// <summary>
    ///This function Populates empty array with random values for very first time.
    /// </summary>
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

    /// <summary>
    /// actual function which sets color per cell, if value = 1 -> white else black
    /// </summary>
    private void SimulateGrid()
    {
        for (int i = 0; i < Cells.Length; i++) //T(n) : O(n)
        {
            Cells[i].SetCellValue(array2D[i / cols, i % cols]);
            Cells[i].SetColor();
        }
    }
    /// <summary>
    /// actual function which takes care of the Simulation and Algorithm
    /// </summary>
    private void SimulateGame() //T(n) : O(n^2)
    {
        var next = new int[rows, cols]; //creating blank array to store the computation result every frame (DisAdv)->Memory Management issue

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int currentCell = array2D[i, j];
                int neighbours = CountNeighbours(array2D, i, j);

                //rules of the Game 
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
        array2D = next; //after computing next grid based on current grid , we are setting current grid as next grid
        SimulateGrid(); //after that simulation will take place i.e. nothing but setting colors on tiles
    }

    /// <summary>
    /// actual function which takes care for counting the neighbours by looking at -1 , 0 and 1th postion from every cell
    /// </summary>
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
        sum -= array2D[x, y]; //we dont want to count ourself as a neighbour so we are reducing it after the computation
        return sum;
    }
}





