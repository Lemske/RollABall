using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCode : MonoBehaviour
{
    [SerializeField]
    private Transform secondArm;
    [SerializeField]
    private Transform minuteArm;
    [SerializeField]
    private Transform hourArm;

    [SerializeField]
    private int speed;

    // Update is called once per frame
    void Update()
    {
        System.DateTime time = System.DateTime.Now;
        float second = time.Second;
        float minute = time.Minute;
        float hour = time.Hour;

        Quaternion secondRotation = Quaternion.Euler(0,  second * 6f, 0); 
        Quaternion minuteRotation = Quaternion.Euler(0, minute * 6f, 0);
        Quaternion hourRotation = Quaternion.Euler(0, (hour % 12f) * 30f - (minute / 2f), 0);

        secondArm.rotation = Quaternion.Slerp(secondArm.rotation, secondRotation, Time.deltaTime * speed);
        minuteArm.rotation = Quaternion.Slerp(minuteArm.rotation, minuteRotation, Time.deltaTime * speed);
        hourArm.rotation = Quaternion.Slerp(hourArm.rotation, hourRotation, Time.deltaTime * speed);
    }
}
