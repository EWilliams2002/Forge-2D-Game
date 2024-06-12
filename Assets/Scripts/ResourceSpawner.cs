using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// Helper class to spawn 2D objects inside an Polygon Collider 2D area for forum.unity.com by Zer0Cool
/// - create an empty GameObject
/// - add a "Polygon Collider 2D" component
/// - edit the vertices of the polygon collider to match your spawning zone (see https://docs.unity3d.com/Manual/class-PolygonCollider2D.html)
/// </summary>
public class ResourceSpawner : MonoBehaviour
{
    public PolygonCollider2D polygonCollider;
    public int numberRandomPositions = 10;
 
    void Start()
    {
        if (polygonCollider == null) GetComponent<PolygonCollider2D>();
        if (polygonCollider == null) Debug.Log("Please assign PolygonCollider2D component.");
 
        int i = 0;
        while ( i < numberRandomPositions)
        {
            Vector3 rndPoint3D = RandomPointInBounds(polygonCollider.bounds, 1f);
            Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
            Vector2 rndPointInside = polygonCollider.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
            if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
            {
                GameObject rndCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                rndCube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                rndCube.transform.position = rndPoint2D;
                i++;
            }
        }
    }
 
    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),
            Random.Range(bounds.min.z * scale, bounds.max.z * scale)
        );
    }
}