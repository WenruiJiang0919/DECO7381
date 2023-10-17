using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Navigation arrows
/// </summary>
public class NavPathArrow : MonoBehaviour
{
    public MeshRenderer meshRenderer;// Arrow 3D Object Quad
    public List<Transform> points = new List<Transform>();// route point
    private List<MeshRenderer> lines = new List<MeshRenderer>();// Show paths

    public float xscale = 1f;// Zoom scale
    public float yscale = 1f;

    void Start()
    {
        // Arrow width scaling value
        xscale = meshRenderer.transform.localScale.x;
        // Arrow height scaling value
        yscale = meshRenderer.transform.localScale.y;
    }

    // Drawing paths
    public void DrawPath()
    {
        if (points == null || points.Count <= 1)
            return;
        for (int i = 0; i < points.Count - 1; i++)
        {
            DrawLine(points[i].position, points[i + 1].position, i);
        }
    }

    // Draw Path Parameters are an array of path points
    public void DrawPath(Vector3[] points)
    {
        if (points == null || points.Length <= 1)
            return;
        for (int i = 0; i < points.Length - 1; i++)
        {
            DrawLine(points[i], points[i + 1], i);
        }
    }

    // Hidden Path
    public void HidePath()
    {
        for (int i = 0; i < lines.Count; i++)
            lines[i].gameObject.SetActive(false);
    }

    private void DrawLine(Vector3 start, Vector3 end, int index)
    {
        Debug.Log(transform.gameObject.name);
        MeshRenderer mr;
        if (index >= lines.Count)
        {
            mr = Instantiate(meshRenderer);
            lines.Add(mr);
        }
        else
        {
            mr = lines[index];
        }

        var tran = mr.transform;
        var length = Vector3.Distance(start, end);
        tran.localScale = new Vector3(xscale, length, 1);
        tran.position = (start + end) / 2;
        // Point to end
        tran.LookAt(end);
        // rotation offset
        tran.Rotate(90, 0, 0);
        mr.material.mainTextureScale = new Vector2(1, length * yscale);
        mr.gameObject.SetActive(true);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 80, 20), "Show the path"))
        {
            DrawPath();
        }
        if (GUI.Button(new Rect(20, 80, 80, 20), "Hide the path"))
        {
            HidePath();
        }
    }
}

