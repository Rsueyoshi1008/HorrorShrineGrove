using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Repository;
public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GenerationManager _generation;
    void Start()
    {
        
        enemy.EventEnemyGeneration = _generation.Generation;
        

        
    }
}
