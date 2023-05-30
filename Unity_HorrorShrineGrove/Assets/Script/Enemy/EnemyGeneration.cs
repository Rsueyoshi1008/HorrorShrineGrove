using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    // Start is called before the first frame update
    
    public void EnemyDefeated()
    {
        
        // 新しい敵を生成
        GameObject sphere_prefab = Resources.Load<GameObject>("EnemyPrefub/SkeletonWarrior 1");
        GameObject sphere1 = Instantiate(sphere_prefab);
        Vector3 currentLocation = transform.position;
        sphere1.transform.position = currentLocation;
        
    }
}
