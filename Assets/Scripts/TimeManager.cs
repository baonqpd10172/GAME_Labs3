using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timeText;
    private float currentTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        UPdateTimeDisplay();
    }
    void UPdateTimeDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string timeString = string.Format("{0:0}:{1:60}", minutes, seconds);
        timeText.text = "Thoi gian da choi: " + timeString;
    }
}
