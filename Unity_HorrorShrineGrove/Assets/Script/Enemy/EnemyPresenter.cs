using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Repository;
public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private GameManager gameManager;
    private GenerationManager _generation;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _generation = GameObject.Find("EnemyManager").GetComponent<GenerationManager>();
        enemy.InitializeDataRepository();
        enemy.EventEnemyGeneration = _generation.Generation;
        

        
    }
}
