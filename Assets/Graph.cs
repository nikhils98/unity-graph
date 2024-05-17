using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    Transform[] points;

    void Awake()
    {
        var step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;

        points = new Transform[resolution];

        for (var i = 0; i < resolution; i++)
        {
            var point = points[i] = Instantiate(pointPrefab);

            position.x = (i + 0.5f) * step - 1f;

            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    void Update()
    {
        var time = Time.time;
        for (var i = 0; i < resolution; i++)
        {
            var point = points[i];
            var position = point.localPosition;
            position.y = Mathf.Sin((position.x + time) * Mathf.PI);
            point.localPosition = position;
        }
    }
}