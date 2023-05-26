using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Repository;
public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        enemy.SetDataRepository(gameManager.GetDataRepository());
        

        enemy.SynModel();
    }
}
