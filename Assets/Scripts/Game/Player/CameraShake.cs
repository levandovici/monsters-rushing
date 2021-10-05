using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 _startPos = Vector3.zero;



    private void Awake()
    {
        _startPos = transform.localPosition;
    }



    public void StartShake()
    {
        StartCoroutine(Shake(0.13f, 0.25f));
    }



    private IEnumerator Shake(float duration, float magnitude)
    {
        float time = 0f;

        while(time < duration)
        {
            time += Time.deltaTime;

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = _startPos + new Vector3(x, y, 0f);

            yield return null;
        }

        transform.localPosition = _startPos;
    }
}