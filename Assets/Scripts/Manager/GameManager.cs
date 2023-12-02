using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject gameEndPanel;

    public void GameEnd(bool isWin)
    {
        Time.timeScale = 0f;

        if (isWin)
        {
            gameEndPanel.GetComponentInChildren<TextMeshProUGUI>().text = "GAME CLEAR";
        }
        else
        {
            gameEndPanel.GetComponentInChildren<TextMeshProUGUI>().text = "GAME OVER";
        }

        gameEndPanel.SetActive(true);
    }
}
