using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {

    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;

    TextMesh textMesh;

    private void Start()
    {
        
    }

    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize; // x is converted to a decimal, then rounded to nearest whole number, then multiplied by gridSize to snap to nearest multiple of gridSize
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = snapPos.x / gridSize+ "," + snapPos.z / gridSize;
    }
}
