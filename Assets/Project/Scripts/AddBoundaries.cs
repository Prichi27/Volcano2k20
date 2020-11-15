using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoundaries : MonoBehaviour
{
    private PolygonCollider2D _pc;
    private void Awake()
    {
        _pc = GetComponent<PolygonCollider2D>();
        if (_pc == null) _pc = gameObject.AddComponent<PolygonCollider2D>();
        _pc.isTrigger = true;
        Vector2[] points = _pc.points;
        EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
        edge.points = points;
        Destroy(_pc);
    }

}
