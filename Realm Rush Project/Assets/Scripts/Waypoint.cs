using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {


    // public ok here as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;


    Vector2Int gridPos;

    const int gridSize = 10;

    

    public int GetGridSize()
    {
        return gridSize;
    }
    public Vector2Int GetGridPos()
    {
        // x is converted to a decimal, then rounded to nearest whole number, then multiplied by gridSize to snap to nearest multiple of gridSize
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print("not placeable");
            }
        }
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
