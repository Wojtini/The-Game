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

    //Backgrounds
    public SpriteRenderer backgroundOne;
    public SpriteRenderer backgroundTwo;
    public int currentBackground = 1;
    public bool backgroundChanging = false;
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
        }
        else
        {
            float newX = Mathf.Clamp(player.transform.position.x, constraints.getLeftConstraint(), constraints.getRightConstraint());
            float newY = Mathf.Clamp(player.transform.position.y, constraints.getDownConstraint(), constraints.getUpConstraint());
            mainCamera.transform.position = new Vector3(newX, newY, mainCamera.transform.position.z);
        }

        if (backgroundChanging)
        {
            if (currentBackground == 1 && backgroundOne.color.a < 1f)
            {
                backgroundOne.color += new Color(0, 0, 0, 0.65f * Time.deltaTime);
            }
            else if (backgroundOne.color.a > 0f)
            {
                backgroundOne.color -= new Color(0, 0, 0, 0.65f * Time.deltaTime);
            }
            else
            {
                backgroundChanging = false;
            }
        }
    }

    public void lockCamera(Vector3 pos)
    {
        cameraLocked = true;
        lockPosition = new Vector3(pos.x, pos.y, this.transform.position.z);
    }

    public void unlockCamera()
    {
        cameraLocked = false;
    }

    public void changeBackgroundImage(Sprite newImage)
    {
        if (currentBackground == 1)
        {
            backgroundTwo.sprite = newImage;
            currentBackground = 2;
        }
        else
        {
            backgroundOne.sprite = newImage;
            currentBackground = 1;
        }
        backgroundChanging = true;
    }
}
