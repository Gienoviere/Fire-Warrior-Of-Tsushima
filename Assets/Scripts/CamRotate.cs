using System.Collections;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
        }
        if (Input.GetKeyDown("e"))
        {
            StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));
        }
    }
}
