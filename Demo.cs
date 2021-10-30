using UnityEngine;

public class Demo : MonoBehaviour
{
    [Tooltip("How much the arc curves.")] public float angle = 20f;
    [Tooltip("How many total rays will be used at most.")] public int rays = 5;
    [Tooltip("How long the arc is.")] public float dist = 1f;
    [Tooltip("Which axis should the arc go in.")] public Vector3 axis = Vector3.right;
    [Tooltip("Mask out layers.")] public LayerMask mask;
    [Tooltip("Rather or not to draw the arc in the editor.")] public bool drawLine = true;
    
    // Update is called once per frame
    void Update()
    {
        ArcRaycaster.ArcCast(transform, angle, rays, dist, axis, mask, drawLine);
    }
}
