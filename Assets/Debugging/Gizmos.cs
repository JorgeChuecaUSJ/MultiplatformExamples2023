using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gizmos : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
        Handles.DrawDottedLine(transform.position, transform.parent.position, 2);
    }
}
