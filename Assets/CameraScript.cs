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
    Vector3 lockPosition;
    public float moveSpeed = 1f;
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
            transform.position = Vector3.Lerp(transform.position, lockPosition, Time.deltaTime * moveSpeed);
            return;
        }
        float newX = Mathf.Clamp(player.transform.position.x,constraints.getLeftConstraint(),constraints.getRightConstraint());
        float newY = Mathf.Clamp(player.transform.position.y,constraints.getDownConstraint(),constraints.getUpConstraint());
        //mainCamera.transform.position = Vector3.Lerp(new Vector3(newX, newY, -10f), lockPosition, Time.deltaTime * moveSpeed * 5);
        mainCamera.transform.position = new Vector3(newX, newY, mainCamera.transform.position.z);
    }

    public void lockCamera(Vector3 pos)
    {
        cameraLocked = true;
        lockPosition = new Vector3(pos.x, pos.y, this.transform.position.z);
        //mainCamera.transform.position = new Vector3(pos.x, pos.y, mainCamera.transform.position.z);
    }

    public void unlockCamera()
    {
        cameraLocked = false;
    }

}
