using System;
using UnityEngine;

public class TowerlampController : MonoBehaviour
{
    public SignController red;
    public SignController yellow;
    public SignController green;

    // 현재 타워램프의 상태
    private LampState state;

    // 각 상태별 유지 시간 (인스펙터에서 수정 가능하도록 public/SerializeField 사용)
    public float greenDuration = 10f;
    public float yellowDuration = 5f;
    public float redDuration = 5f;

    // 상태 전환 및 깜박임을 위한 타이머 변수들
    private float stateTimer = 0f;
    private float blinkTimer = 0f;
    [SerializeField] private float blinkSpeed = 0.5f; // 0.5초 주기로 노란등 깜박임

    public enum LampState
    {
        Green = 0,
        Yellow = 1,
        Red = 2
    }

    private void Start()
    {
        SetState(LampState.Green);
    }

    private void Update()
    {
        stateTimer += Time.deltaTime;

        switch (state)
        {
            case LampState.Green:
                green.IsOn = true;

                if (stateTimer >= greenDuration)
                {
                    SetState(LampState.Yellow);
                }
                break;

            case LampState.Yellow:
                blinkTimer += Time.deltaTime;
                if (blinkTimer >= blinkSpeed)
                {
                    yellow.IsOn = !yellow.IsOn;
                    blinkTimer = 0f;
                }

                if (stateTimer >= yellowDuration)
                {
                    SetState(LampState.Red);
                }
                break;

            case LampState.Red:
                red.IsOn = true;

                if (stateTimer >= redDuration)
                {
                    SetState(LampState.Green);
                }
                break;
        }
    }

    // 상태가 바뀔 때 타이머를 리셋하고 다른 전등을 꺼주는 함수
    private void SetState(LampState newState)
    {
        state = newState;
        stateTimer = 0f; // 상태가 바뀔 때마다 타이머를 0으로 초기화
        blinkTimer = 0f; // 깜박임 타이머도 초기화

        // 상태가 바뀔 때 이전 상태의 불빛들이 켜져있을 수 있으므로 싹 꺼줍니다.
        red.IsOn = false;
        yellow.IsOn = false;
        green.IsOn = false;
    }
}
