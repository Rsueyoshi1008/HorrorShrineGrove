using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCount : MonoBehaviour
{
    private float disappearTime = 5f; // 弾が消えるまでの待機時間（秒）

    private float elapsedTime;// // 弾が発射されてからの経過時間
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // 経過時間が待機時間を超えた場合、弾を消す
        if (elapsedTime >= disappearTime)
        {
            Destroy(gameObject);
            
        }
    }
    public void BulletTimeLapse()
    {
        disappearTime = Time.time;
        
    }
}
