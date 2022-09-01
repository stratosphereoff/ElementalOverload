using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Inctance { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI manaText;
    private int _score;
    private int _mana;

    public int Score
    {
        get => _score;

        set
        {
            if (_score == value) return;

            _score = value;

            scoreText.SetText($"Score : {_score}");
        } 
    }

    public int Mana
    {
        get => _mana;

        set
        {
            if (_mana == value) return;

            _mana = value;

            manaText.SetText($"Mana : {_mana}");
        } 
    }

    private void Awake() => Inctance = this;
}
