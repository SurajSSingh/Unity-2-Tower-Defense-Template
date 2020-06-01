using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSelection : MonoBehaviour
{
    private Vector3 screenOffset;
    private Vector3 cellOffset;
    public GridLayout grid;

    // Start is called before the first frame update
    void Start()
    {
        screenOffset = new Vector3(0,0,10);
        cellOffset = new Vector3(0.5f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CursorPosition();
    }

    void CursorPosition()
    {
        Vector3 position =
            grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)
            + screenOffset);

        this.transform.position = position + cellOffset;
    }
}
