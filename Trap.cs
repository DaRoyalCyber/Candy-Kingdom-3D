using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{


    public Transform leftTrap;
    public Transform rightTrap;

    public float openAngle = 90f;
    public float rotateSpeed = 2f;
    public float openDuration = 2f;

    Quaternion leftClosedRot;
    Quaternion rightClosedRot;

    Quaternion leftOpenRot;
    Quaternion rightOpenRot;

    bool isOpen = false;


    private void Start()
    {
        leftClosedRot = leftTrap.localRotation;

        rightClosedRot = rightTrap.localRotation;

        leftOpenRot = leftClosedRot * Quaternion.Euler(0,0,- openAngle);
        rightOpenRot = rightClosedRot * Quaternion.Euler(0f,0f,-openAngle);

    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    IEnumerator OpenAndClose()
    {
        isOpen = true;
        SpinningAudio.instance.PlayObjectFalling();

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * rotateSpeed;

            leftTrap.localRotation = Quaternion.Slerp(leftClosedRot, leftOpenRot, t);
            rightTrap.localRotation= Quaternion.Slerp(rightClosedRot, rightOpenRot, t);
            yield return null;
        }

        yield return new WaitForSeconds(openDuration);

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * rotateSpeed;
            leftTrap.localRotation = Quaternion.Slerp(leftOpenRot, leftClosedRot, t);
            rightTrap.localRotation = Quaternion.Slerp(rightOpenRot, rightClosedRot, t);
            yield return null;
        }
      
        isOpen = false;
    }
    public void ActivateTrap()
    {
        if (!isOpen)
            StartCoroutine(OpenAndClose());
    }
}