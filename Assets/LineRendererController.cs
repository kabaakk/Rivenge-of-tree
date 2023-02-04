using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineRendererController : Singleton<LineRendererController>
{
    private LineRenderer _lineRenderer;
    
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        ActionManager.instance.ArenaSurvived += ArenaSurvived;
        ActionManager.instance.SeedThrown += SeedThrown;
        SeedThrown();
    }
   
    public void DrawLine(Vector3 start, Vector3 end)
    {
       
        _lineRenderer.SetPosition(0, start);
        _lineRenderer.SetPosition(1, end);
    }


    private void ArenaSurvived()
    {
        // Open line renderer
        _lineRenderer.enabled = true;
    }
    
    private void SeedThrown()
    {
        // Close line renderer
        _lineRenderer.enabled = false;
    }
    
    
}
