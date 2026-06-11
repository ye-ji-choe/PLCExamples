using System;
using UnityEngine;

public class TowerlampController_T : MonoBehaviour
{
    //램프의 상태를 정의한 열거형
    public enum LampState
    {
        Green,
        Yellow,
        Red
    }

    public SignController red;
    public SignController yellow;
    public SignController green;
    public LampState currentState;      //현재 상태
    public float greenDuration = 30f;   //각 램프 상태의 유지시간
    public float yellowDuration = 5f;
    public float redDuration = 10f;
    public float blinkDuration = 0.5f;

    public float nextStateTime;
    private float nextBlinkTime;

    private void Start()
    {
        currentState = LampState.Green;
        nextStateTime = Time.time + greenDuration;
    }


    private void Update()
    {
        switch (currentState)
        {
            case LampState.Green:
                UpdateGreen();
                break;
            case LampState.Yellow:
                UpdateYellow();
                break;
            case LampState.Red:
                UpdateRed();
                break;
            default:
                break;
        }
    }

    private void UpdateRed()
    {
        if(nextStateTime < Time.time)
        {
            currentState = LampState.Green;
            green.IsOn = true;
            yellow.IsOn = false;
            red.IsOn = false;
            nextStateTime = Time.time + greenDuration;

            return;
        }
    }

    private void UpdateYellow()
    {
        if (nextStateTime < Time.time)
        {
            currentState = LampState.Red;
            green.IsOn = false;
            yellow.IsOn = false;
            red.IsOn = true;
            nextStateTime = Time.time + redDuration;
            return;
        }

        if(nextBlinkTime < Time.time)
        {
            nextBlinkTime = Time.time + blinkDuration;
            yellow.IsOn = !yellow.IsOn;
        }
        
    }

    private void UpdateGreen()
    {
        if (nextStateTime < Time.time)
        {
            currentState = LampState.Yellow;
            green.IsOn = false;
            yellow.IsOn = true;
            red.IsOn = false;
            nextBlinkTime = Time.time + blinkDuration;
            nextStateTime = Time.time + greenDuration;
            return;
        }
        
    }
}
