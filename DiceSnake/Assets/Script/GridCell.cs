using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Transform anchor;

    public GPE cellContent { get; private set; } = null ;

    public bool IsEmpty()
    {
        return cellContent == null;
    }

    public void changeContent(GPE newContent)
    {
        cellContent = newContent;
    }
}