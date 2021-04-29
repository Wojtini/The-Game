using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRoom : MonoBehaviour
{
    public Transform cameraPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        CameraScript.instance.lockCamera(cameraPosition.transform.position);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        CameraScript.instance.unlockCamera();

    }
}
