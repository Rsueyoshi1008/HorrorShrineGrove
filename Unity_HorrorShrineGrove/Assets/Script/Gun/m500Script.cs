using UnityEngine;
using UnityEngine.Events;
using InGame.Gun.Model;
using Data.Repository;

public class m500Script : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BulletCount bulletCount;
    private DataRepository _repository;
    private m500Model _model;
    public GameObject bulletPrefab; // 弾のプレハブ
    public Transform barrel; // 弾の発射位置

    private int maxAmmoCount = 0;//最大弾数
    private float nextFireTime = 0f; // 次の発射時刻
    public UnityAction EventBulletView;
    
    

    public float reloadTime = 2f; // リロードにかかる時間
    private bool isReloading = false; // リロード中かどうかのフラグ

    private GameObject shooter; // 発射したオブジェクト（銃）の参照
    private float initialX; // 弾の初期X座標

    


    
    public void SetDataRepository()
    {
        _repository = gameManager.GetDataRepository();
        _model = new m500Model();
        initialX = transform.position.x; // 弾の初期X座標を保存
    }
    public void SynModel()
    {
        var gun = _repository.m500;
        maxAmmoCount = gun.GunBullet;
        _model.GunBullet = gun.GunBullet;
    }

    private void Update()
    {
        if (isReloading)
        {
            return; // リロード中は発射処理をスキップ
        }

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && _model.GunBullet > 0) // 左クリックが押されたらかつ発射レートの制限と弾が残っている場合
        {
            Fire(); // 発射メソッドを呼び出す
            nextFireTime = Time.time + 0.5f; // 次の発射時刻を更新する
            _model.GunBullet--; // 弾数を減らす
            SynDataRepository();
            
            if (_model.GunBullet == 0) // 残弾数が0になったらリロード開始
            {
                Reload();
            }
            bulletCount.BulletTimeLapse();
        }
        

        if (Input.GetKeyDown(KeyCode.R) && _model.GunBullet < maxAmmoCount) // Rキーが押されたらかつ弾が最大弾数未満の場合
        {
            Reload(); // リロードメソッドを呼び出す
        }

    }

    public void SetBulletInfo(GameObject shooterObject)
    {
        shooter = shooterObject; // 発射したオブジェクト（銃）を保存
    }

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // 敵に当たった場合は弾を削除
            
        }
    }

    private void Fire()
    {
        // 弾のインスタンスを生成し、発射位置に配置する
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);

        // Rigidbodyコンポーネントを取得して、弾に力を加える
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(barrel.forward * 1000f); // 1000fは発射の力の大きさを表す値です
    }

    private void Reload()
    {
        isReloading = true; // リロード中フラグを立てる

        // リロードにかかる時間後に弾数をリセット
        Invoke("ResetAmmo", reloadTime);
    }

    private void ResetAmmo()
    {
        _model.GunBullet = maxAmmoCount; // 弾数を最大弾数にリセット
        SynDataRepository();
        isReloading = false; // リロード中フラグを解除
        
    }
    private void SynDataRepository()
    {
        
        _repository.player.Bullet = _model.GunBullet;
        EventBulletView?.Invoke();
    }
}