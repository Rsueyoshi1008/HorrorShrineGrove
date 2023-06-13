using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Repository;
public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private GameManager gameManager;
    private GenerationManager _generation;
    private PlayerView _playerView;
    void Start()
    {
        _playerView = GameObject.Find("Player").GetComponent<PlayerView>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _generation = GameObject.Find("EnemyManager").GetComponent<GenerationManager>();
        enemy.InitializeDataRepository();
        enemy.EventDamage = _playerView.Damage;
        enemy.EventEnemyGeneration = _generation.Generation;
        enemy.SynModel();

        
    }
}
