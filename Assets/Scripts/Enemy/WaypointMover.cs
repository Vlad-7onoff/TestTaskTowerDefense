using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    private float _moveSpeed;
    private Transform _path;
    private int _currentPoint = 0;

    private Transform[] _points;

    public void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;
        }
    }

    public void Init(float moveSpeed, Transform _path)
    {
        _moveSpeed = moveSpeed;
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);
    }
}
