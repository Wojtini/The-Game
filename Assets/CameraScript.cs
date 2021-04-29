using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static CameraScript instance;

    Camera mainCamera;
    GameObject player;
    LevelConstraints constraints;

    bool cameraLocked = false;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        constraints = LevelConstraints.instance;
    }
    // Update is called once per frame
    void Update()
    {
        if (cameraLocked)
        {
            return;
        }
        float newX = Mathf.Clamp(player.transform.position.x,constraints.getLeftConstraint(),constraints.getRightConstraint());
        float newY = Mathf.Clamp(player.transform.position.y,constraints.getDownConstraint(),constraints.getUpConstraint());
        mainCamera.transform.position = new Vector3(newX, newY, mainCamera.transform.position.z);
    }

    public void lockCamera(Vector3 pos)
    {
        cameraLocked = true;
        mainCamera.transform.position = new Vector3(pos.x, pos.y, mainCamera.transform.position.z);
    }

    public void unlockCamera()
    {
        cameraLocked = false;
    }
}
