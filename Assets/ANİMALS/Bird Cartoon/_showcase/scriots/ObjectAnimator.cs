using UnityEngine;
using System.Collections;

public class ObjectAnimator : MonoBehaviour
{
    [Header("Translation Attributes")]
    public Vector3 positionFrom;
    public Vector3 positionTo;
    public float translationDuration = 1f;

    [Header("Rotation Attributes")]
    public float RotationSpeed = 100.0f;
    public bool positiveRotation = false;
    public bool RotateX = false;
    public bool RotateY = false;
    public bool RotateZ = false;

    private int posOrNeg = 1;

    void Start()
    {
        if (positiveRotation == false)
        {
            posOrNeg = -1;
        }
    }

    void Update()
    {
        transform.position = Vector3.Lerp(positionFrom, positionTo, Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time / translationDuration, 1f)));

        if (RotateX)
        {
            transform.Rotate(RotationSpeed * Time.deltaTime * posOrNeg, 0, 0);
        }
        if (RotateY)
        {
            transform.Rotate(0, RotationSpeed * Time.deltaTime * posOrNeg, 0);
        }
        if (RotateZ)
        {
            transform.Rotate(0, 0, RotationSpeed * Time.deltaTime * posOrNeg);
        }
    }
}