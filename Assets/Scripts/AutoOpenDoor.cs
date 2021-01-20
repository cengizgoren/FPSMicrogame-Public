using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOpenDoor : MonoBehaviour
{
    public float openDuration = 0.5f;
    public Vector3 openDir;
    public float openDis;
    public Transform doorObj;

    public bool canClose = true;
    Vector3 originPos;

    private void Start()
    {
        originPos = doorObj.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveDoor(false));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!canClose)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveDoor(true));
        }
    }

    IEnumerator MoveDoor(bool isClosing)
    {
        float percent = 0f;

        while (percent < 1)
        {
            percent += Time.deltaTime / openDuration;

            if (isClosing)
            {
                doorObj.localPosition = Vector3.Lerp(originPos + openDir * openDis, originPos, percent);
            }
            else
            {
                doorObj.localPosition = Vector3.Lerp(originPos, originPos + openDir * openDis, percent);
            }

            yield return null;
        }
    }
}
