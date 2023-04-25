using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public PlayerController playerControl;

    const float degreesPerHour = 1f; // 360 seconds -> 1 rotation
    const float degreesPerMinute = 6f; // 60 seconds -> 1 rotation
    const float degreesPerSecond = 60f; // 6 seconds -> 1 rotation

    public Transform hoursTransform, minutesTransform, secondsTransform;

    // Update is called once per frame
    void Update()
    {
        if (playerControl.gameActive)
        {
            hoursTransform.Rotate(new Vector3(0, degreesPerHour, 0) * Time.deltaTime);
            minutesTransform.Rotate(new Vector3(0, degreesPerMinute, 0) * Time.deltaTime);
            secondsTransform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
        }
    }

}