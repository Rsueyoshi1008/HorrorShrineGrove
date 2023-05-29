using UnityEngine;

public class m500Script : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public Transform barrel; // 弾の発射位置

    //public float fireRate = 0.1f; // 発射レート（秒間の発射回数）
    private float nextFireTime = 0f; // 次の発射時刻

    public int maxAmmoCount = 30; // 最大弾数
    private int ammoCount; // 残弾数

    public float reloadTime = 2f; // リロードにかかる時間
    private bool isReloading = false; // リロード中かどうかのフラグ

    private GameObject shooter; // 発射したオブジェクト（銃）の参照
       private float initialX; // 弾の初期X座標


    private void Start()
    {
        ammoCount = maxAmmoCount; // 初期弾数を最大弾数に設定
        initialX = transform.position.x; // 弾の初期X座標を保存

    }

    private void Update()
    {
        if (isReloading)
        {
            return; // リロード中は発射処理をスキップ
        }

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && ammoCount > 0) // 左クリックが押されたらかつ発射レートの制限と弾が残っている場合
        {
            Fire(); // 発射メソッドを呼び出す
            nextFireTime = Time.time + 0.5f; // 次の発射時刻を更新する
            ammoCount--; // 弾数を減らす

            if (ammoCount == 0) // 残弾数が0になったらリロード開始
            {
                Reload();
            }
        }
        

        if (Input.GetKeyDown(KeyCode.R) && ammoCount < maxAmmoCount) // Rキーが押されたらかつ弾が最大弾数未満の場合
        {
            Reload(); // リロードメソッドを呼び出す
        }

        float distance = Mathf.Abs(transform.position.x - initialX); // 弾の現在のX座標と初期X座標の距離を計算

        if (distance >= 200f)
        {
            Destroy(gameObject); // X座標の移動距離が200以上になった場合は弾を削除
            Debug.Log("Bullet traveled 200 units on the X-axis.");
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
            Debug.Log("Bullet hit enemy!");
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
        Debug.Log("Reloading...");

        // リロードにかかる時間後に弾数をリセット
        Invoke("ResetAmmo", reloadTime);
    }

    private void ResetAmmo()
    {
        ammoCount = maxAmmoCount; // 弾数を最大弾数にリセット
        isReloading = false; // リロード中フラグを解除
        Debug.Log("Reload complete. Ammo count: " + ammoCount);
    }
}