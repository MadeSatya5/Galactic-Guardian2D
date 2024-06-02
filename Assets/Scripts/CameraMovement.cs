using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float baseCameraSpeed = 9f;
    private float speedIncreaseFactor = 1f;
    private ScoreManager scoreManager;
    public float cameraSpeed;
    private float maxCameraSpeed = 40f;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        cameraSpeed = baseCameraSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManager != null)
        {
            if(cameraSpeed < maxCameraSpeed)
            {
                float speedIncrease = scoreManager.Score * speedIncreaseFactor;
                cameraSpeed = baseCameraSpeed + speedIncrease; // Update kecepatan kamera
            }
            else if(cameraSpeed > maxCameraSpeed)
            {
                cameraSpeed = maxCameraSpeed;
            }
        }
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}
