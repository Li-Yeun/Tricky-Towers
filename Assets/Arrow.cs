using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public bool Lock;
    [SerializeField] float CameraTurnSpeed = 0.1f;
    [SerializeField] Vector3[] Postions;
    [SerializeField] Quaternion[] Rotations;
    [SerializeField] GameObject FakeArrow;
    [SerializeField] float Delay;

    float currentRotation;
    void Start()
    {
        currentRotation = Mathf.Abs(this.transform.rotation.z);
        Lock = false;

    }

    public void RotateArrow(float rotateAngle)
    {
        Lock = true;
        currentRotation = Mathf.Abs(this.transform.rotation.z);
        float Nextrotaion = currentRotation + rotateAngle;
        FakeArrow.transform.RotateAround(new Vector3(5.5f, 5.5f, 0), Vector3.forward, rotateAngle);
        if (rotateAngle == -90)
        {
            StartCoroutine(RotateMeInverse(Nextrotaion));
        } else
            StartCoroutine(RotateMe(Nextrotaion));
    }

    IEnumerator RotateMe(float NextRotation)
    {
        for (var t = this.transform.rotation.z; t < NextRotation; t += 3)
        {
            transform.RotateAround(new Vector3(5.5f, 5.5f, 0), Vector3.forward, 3);
            yield return null;
        }

        transform.rotation = FakeArrow.transform.rotation;
        transform.position = FakeArrow.transform.position;
        Invoke("RemoveLock", Delay);

    }

    IEnumerator RotateMeInverse(float NextRotation)
    {
        for (var t = this.transform.rotation.z; t > NextRotation; t -= 3)
        {
            transform.RotateAround(new Vector3(5.5f, 5.5f, 0), -Vector3.forward, 3);
            yield return null;
        }

        transform.rotation = FakeArrow.transform.rotation;
        transform.position = FakeArrow.transform.position;
        Invoke("RemoveLock", Delay);
    }

    void RemoveLock()
    {
        Lock = false;
    }
}
