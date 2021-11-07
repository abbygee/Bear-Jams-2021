using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {
    [SerializeField] float totalTime;
    [SerializeField] Text timerText;
    [SerializeField] GameObject levelCompletePanel;
    //float totalTime;
    float timeRemaining;
    bool levelOver = false;

    [SerializeField] [Tooltip("scene transition timer")] 
    private float sceneTimer;
    [SerializeField] [Tooltip("true if sceneTimer is needed, false if not")] 
    private bool sceneLimit;

    private void Awake() {
        timeRemaining = totalTime;
        if (totalTime != 243f)
        {
            timeRemaining = GameManager.Instance.gameState.GlobalTime; //test
        }
    }

    private void Update() {
        if (GameManager.Instance.gameState.GlobalTime < 240f)
        {
            totalTime = GameManager.Instance.gameState.GlobalTime;
        }

        if (sceneLimit)
        {
            sceneTimer -= Time.deltaTime;
            if (sceneTimer <= 0) 
            {
                GameManager.Instance.StartGame();
            }
        }

        if (!levelOver) {
            GameManager.Instance.gameState.GlobalTime = timeRemaining;
            timeRemaining = Mathf.Max(0f, timeRemaining - Time.deltaTime);
            UpdateTimerText();
            if (timeRemaining <= 0) {
                levelOver = true;
                EndLevel();
            }
        }
    }

    void UpdateTimerText() {
        if (timerText != null) {
            string minutes = Mathf.Floor(10 - timeRemaining / 60).ToString("00");
            string seconds = Mathf.Floor(60 - timeRemaining % 60).ToString("00");

            timerText.text = string.Format("{0}:{1} AM", minutes, seconds);
            GameManager.Instance.gameState.GlobalTimeString = timerText.text;
        }
        else {
            Debug.LogWarning("No timer text");
        }
    }

    void EndLevel() {
        // Turn on level complete darkened panel
        if (levelCompletePanel != null) {
            levelCompletePanel.SetActive(true);
        } else {
            Debug.LogWarning("No level complete panel");
        }
    }
}