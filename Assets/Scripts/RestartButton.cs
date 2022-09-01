using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void Restart()
    {
        Board.Instance.ResetBoard();
        EnemyBoard.Instance.ResetBoard();
        panel.SetActive(false);
        ScoreCounter.Inctance.Score = 0;
        ScoreCounter.Inctance.Mana = 0;
    }
}
