using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Camera mainCamera;
    GameObject player;
    LevelConstraints constraints;
    // Start is called before the first frame update
    void Awake()
    {
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
        float newX = Mathf.Clamp(player.transform.position.x,constraints.getLeftConstraint(),constraints.getRightConstraint());
        float newY = Mathf.Clamp(player.transform.position.y,constraints.getDownConstraint(),constraints.getUpConstraint());
        mainCamera.transform.position = new Vector3(newX, newY, mainCamera.transform.position.z);
    }
}
