using UnityEngine;

public class ArcRaycaster : MonoBehaviour
{
    /// <summary>
    /// Fire a raycast in an arc.
    /// </summary> 
    /// <param name="start">Starting point of the raycast, also uses rotation.</param>
    /// <param name="rayAngle">How much the arc curves.</param>
    /// <param name="rays">How many total rays will be used at most.</param>
    /// <param name="rayDist">How long the arc is.</param>
    /// <param name="axis">Which axis should the arc go in.</param>
    /// <param name="mask">Mask out layers.</param>
    /// <param name="drawLine">Rather or not to draw the arc in the editor.</param>
    public static RaycastHit ArcCast(Transform start, float rayAngle, int rays, float rayDist, Vector3? axis = null, LayerMask mask = new LayerMask(), bool drawLine = false)
    {
        if (axis == null)
            axis = Vector3.right;
        Transform trans = new GameObject().transform;
        trans.position = start.position;
        trans.rotation = start.rotation;
        Vector3 lastHit = Vector3.zero;

        for (int i = 0; i < rays; i++)
        {
            if(i == 0)
            {
                if (Physics.Raycast(start.position, trans.forward, out RaycastHit hit, rayDist, mask))
                {
                    if(drawLine)
                        Debug.DrawLine(start.position, hit.point, Color.red);
                    Destroy(trans.gameObject);
                    return hit;
                }

                lastHit = start.position + (trans.forward * rayDist);
                if(drawLine)
                    Debug.DrawLine(start.position, lastHit, Color.red);
            }
            else
            {
                trans.Rotate(axis.Value * rayAngle, Space.Self);

                if (Physics.Raycast(lastHit, trans.forward, out RaycastHit hit, rayDist, mask))
                {
                    if(drawLine)
                        Debug.DrawLine(lastHit, hit.point, Color.red);
                    Destroy(trans.gameObject);
                    return hit;
                }

                Vector3 ogLastHit = lastHit;
                lastHit += trans.forward * rayDist;
                if(drawLine)
                    Debug.DrawLine(ogLastHit, lastHit, Color.red);
            }
        }

        Destroy(trans.gameObject);
        return new RaycastHit();
    }
}
