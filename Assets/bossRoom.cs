using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRoom : MonoBehaviour
{
    public string bossDisplayName = "DEFAULT_BOSS_NAME";
    public string descDisplayName = "DEFAULT_DESC";
    public float lifetime = 5f;
    public Sprite fightBackground;

    public Transform cameraPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        CameraScript.instance.lockCamera(cameraPosition.transform.position);
        PlayerGUI.instance.ShowTextPrompt(bossDisplayName, descDisplayName, lifetime);

        if (fightBackground != null)
        {
            CameraScript.instance.changeBackgroundImage(fightBackground);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        CameraScript.instance.unlockCamera();
        CameraScript.instance.changeBackgroundImage(LevelInfo.instance.levelBackground);
    }
}
