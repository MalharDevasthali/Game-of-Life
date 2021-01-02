using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private int vaule;
    [SerializeField] private Image cellImage;
    public int GetCellValue()
    {
        return vaule;
    }
    public void SetCellValue(int _value)
    {
        vaule = _value;
    }
    public void SetColor()
    {
        if (vaule == 0)
        {

            cellImage.color = Color.black;
        }
        else
        {
            cellImage.color = Color.white;
        }
    }

}
