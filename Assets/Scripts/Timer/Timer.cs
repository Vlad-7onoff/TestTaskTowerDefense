using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float _timer = 0f;
    private float _timeThreshold;

    public UnityAction OnTimeGone;

    private void Update()
    {
        if (_timer < _timeThreshold)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            _timer = 0f;
            OnTimeGone.Invoke();
        }
    }

    public void SetTimeThreshold(float time)
    {
        _timeThreshold = time;
    }
}
