using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class EnemyBoard : MonoBehaviour
{
    public static EnemyBoard Instance { get; private set; }
    [SerializeField] private GameObject winPanel;

    private void Awake() => Instance = this;

    public List<EnemyTile> _aliveEnemies;
    public EnemyRow[] rows;
    public EnemyTile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1); 

    private const float TweenDuration = 0.25f;

    private void Update() 
    {
        //  if (Input.GetKeyDown(KeyCode.A))
        // {
        //     ResetBoard();
        // }
    }

    public void ResetBoard()
    {
        Tiles = new EnemyTile[rows.Max(row => row.tiles.Length), rows.Length];
        
        for(var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = rows[y].tiles[x];
                
                tile.x = x;
                tile.y = y;

                tile.Enemy = EnemyDatabase.Enemies[Random.Range(0, EnemyDatabase.Enemies.Length)];

                Tiles[x, y] = tile;

                tile.Reset();
            }
        }

    }

    public void DamageEnemy()
    {
        _aliveEnemies = new List<EnemyTile>();

        for (var y = 0; y < 3; y++)
        {
            var tile = rows[y].tiles[0];

             if(tile.isDead == false)
             {
                _aliveEnemies.Add(tile);
             }
        }

        if(_aliveEnemies.Count > 0)
        {
            int randomEnemyIndex = Random.Range(0, _aliveEnemies.Count - 1);
            var randomEnemy = _aliveEnemies[randomEnemyIndex];
            randomEnemy.TakeDamage();
        }

        CheckIfAlive();
    }

    private void CheckIfAlive()
    {
        _aliveEnemies = new List<EnemyTile>();

        for (var y = 0; y < 3; y++)
        {
            var tile = rows[y].tiles[0];

             if(tile.isDead == false)
             {
                _aliveEnemies.Add(tile);
             }
        }

        if(_aliveEnemies.Count < 1)
        {
            ScoreCounter.Inctance.Score += 1000;
            ResetBoard();
            if(ScoreCounter.Inctance.Score > 4999)
            {
                EndGame();
            } 
        }
    }

    private void EndGame() 
    {
        Board.Instance.mainPanel.SetActive(true);
        winPanel.SetActive(true);
    }
}
