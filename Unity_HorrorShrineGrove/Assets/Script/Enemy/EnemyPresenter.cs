using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Repository;
public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private EnemyGeneration _generation;
    void Start()
    {
        enemy.SetDataRepository(gameManager.GetDataRepository());
        enemy.EventEnemyGeneration = _generation.EnemyDefeated;

        enemy.SynModel();
    }
}
