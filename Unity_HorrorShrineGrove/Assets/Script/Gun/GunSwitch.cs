using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject[] weapons; // 使用可能な武器の配列
    private int currentWeaponIndex = 0; // 現在の武器のインデックス

    private void Start()
    {
        SetCurrentWeapon(currentWeaponIndex); // 最初の武器を設定
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchWeapon(); // Tabキーが押されたら武器を切り替える
        }
    }

    private void SwitchWeapon()
    {
        int nextWeaponIndex = (currentWeaponIndex + 1) % weapons.Length; // 次の武器のインデックスを計算

        SetCurrentWeapon(nextWeaponIndex); // 次の武器を設定
    }

    private void SetCurrentWeapon(int weaponIndex)
    {
        // 現在の武器を非アクティブにする
        weapons[currentWeaponIndex].SetActive(false);

        // 指定した武器をアクティブにする
        weapons[weaponIndex].SetActive(true);

        currentWeaponIndex = weaponIndex; // 現在の武器のインデックスを更新
    }
}