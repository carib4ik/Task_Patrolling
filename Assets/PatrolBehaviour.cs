using System;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _delayAtPoint;

    private int _currentPoint = 0;
    private float _keepDelay;

    private void Start()
    {
        _keepDelay = _delayAtPoint;
    }

    private void Update()
    {
        MoveToNextPoint();

        if (transform.position == _points[_currentPoint].position)
        {
            KeepDelay();
            
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
        
    }

    private void MoveToNextPoint()
    {
        var step = Time.deltaTime * _speed;
            
        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].position, step);
    }

    private void KeepDelay()
    {
        _keepDelay -= Time.deltaTime;

        if (_keepDelay <= 0)
        {
            _currentPoint++;
            _keepDelay = _delayAtPoint;
        }
    }
}
