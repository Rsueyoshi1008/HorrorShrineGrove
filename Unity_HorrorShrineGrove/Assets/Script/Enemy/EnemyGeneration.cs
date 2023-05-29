using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyDefeated()
    {
        Debug.Log("EnemyCreate");
        // 新しい敵を生成
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        // 必要ならば、新しい敵の初期設定を行う

        // 生成した敵の操作や管理を行う必要がある場合は、ここで処理を追加する
    }
}
