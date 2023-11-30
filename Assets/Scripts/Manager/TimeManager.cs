using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float startTime;
    [SerializeField] private float currentTime;

    [SerializeField] TextMeshProUGUI timeText;

    void Start()
    {
        // ���� �ð� ���
        startTime = Time.time;
    }

    void Update()
    {
        // ���� �ð� ���
        currentTime = Time.time - startTime;

        // 1�ʸ��� �ؽ�Ʈ ����
        if (currentTime >= 1.0f && currentTime < 600.0f && currentTime % 1.0f < Time.deltaTime)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60.0f);
            int seconds = Mathf.FloorToInt(currentTime % 60.0f);

            timeText.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";
        }
    }
}