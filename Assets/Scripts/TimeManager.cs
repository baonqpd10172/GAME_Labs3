
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public Text timeText;
    public float totalTime = 10.0f; // Thời gian chơi tổng cộng
    private float currentTime = 0;
    private bool isGameOver = false;
    public PlayerData playerData;
    void Start()
    {
        playerData.playerLevel = 0;
        playerData.playerScore = 0;

        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            PlayerPrefs.SetInt("PlayerLevel", 0);
            PlayerPrefs.SetInt("PlayerScore", 0);


        }
    }
    void Update()
    {
        if (!isGameOver)
        {
            currentTime += Time.deltaTime;
            UpdateTimeDisplay();

            if (currentTime >= totalTime)
            {
                GameOver();
            }
        }
    }

    void UpdateTimeDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string timeString = string.Format("{0:0}:{1:00}", minutes, seconds);
        timeText.text = "Time: " + timeString;
    }

    void GameOver()
    {
        isGameOver = true;

        // Hiển thị màn hình Game Over, có thể thực hiện thông qua việc kích hoạt một panel Game Over trong Canvas
        Debug.Log("Game Over!");
    }
}
