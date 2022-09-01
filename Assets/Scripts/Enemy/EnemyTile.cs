using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class EnemyTile : MonoBehaviour
{
    public int x;
    public int y;

    public int healthMax;
    public int health;

    private Enemy _enemy;
    public bool isDead;
    public Image icon;

    [SerializeField] private TextMeshProUGUI enemyName;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject deathOverlay;
    
    public Enemy Enemy
    {
        get => _enemy;

        set
        {
            if(_enemy == value) return;

            _enemy = value;

            icon.sprite = _enemy.sprite;
            enemyName.text = _enemy.ToString();
            healthMax = _enemy.health;
            health = healthMax;
            healthText.text = health.ToString();
        }
    }

    public void Reset() 
    {
        isDead = false;
        deathOverlay.SetActive(false);
        health = healthMax;
        healthText.text = health.ToString();
    }

    public void TakeDamage()
    {
        health -= 25;
        healthText.text = health.ToString();
        if(health <= 0 && !isDead)
        {
            healthText.text = "Dead";
            ScoreCounter.Inctance.Score += _enemy.value * 100;
            isDead = true;
            deathOverlay.SetActive(true);
        }
    }
}
