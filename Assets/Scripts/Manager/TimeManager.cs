using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float startTime;
    private float currentTime;

    [SerializeField] TextMeshProUGUI timeText;

    void Start()
    {
        // 시작 시간 기록
        startTime = Time.time;
    }

    void Update()
    {
        // 현재 시간 계산
        currentTime = Time.time - startTime;

        // 1초마다 텍스트 갱신
        if (currentTime >= 1.0f && currentTime % 1.0f < Time.deltaTime)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60.0f);
            int seconds = Mathf.FloorToInt(currentTime % 60.0f);

            timeText.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";
        }
    }
}
