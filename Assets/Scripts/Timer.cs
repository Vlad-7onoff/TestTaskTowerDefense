using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public IEnumerator SetTimeOut(UnityAction callback, float time)
    {
        yield return new WaitForSeconds(time);
        callback?.Invoke();
    }
}
