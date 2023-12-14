using System.Drawing;
using UnityEditor;
using UnityEngine;
using Color = UnityEngine.Color;

public class MiddlePoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        var transforms = GetComponentsInChildren<Transform>();

        Vector3 middle = Vector3.zero;

        foreach (var trans in transforms)
        {
            middle += trans.position;
        }

        middle /= transforms.Length;

        //Handles.color = Handles.xAxisColor;
        //Handles.SphereHandleCap(
        //    0,
        //    transform.position,
        //    Quaternion.identity,
        //    1,
        //    EventType.Repaint
        //);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(middle, 1);
    }
}
