using UnityEngine;
using UnityEngine.Events;
using InGame.Model.Gun.GunSwitch;
using Data.Repository;
public class GunSwitch : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private DataRepository _repository;
    public GameObject[] weapons; // 使用可能な武器の配列
    private int currentWeaponIndex = 0; // 現在の武器のインデックス
    private GunSwitchModel _model;
    public UnityAction<int> EventSwitchGun;
    
    public void SetDataRepository()
    {
        _repository = gameManager.GetDataRepository();
        _model = new GunSwitchModel();
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
        if(weaponIndex == 0)//m500
        {
            _model.Bullet = _repository.m500.GunBullet;
            EventSwitchGun?.Invoke(_model.Bullet);
        }
        if(weaponIndex == 1)//AK
        {
            _model.Bullet = _repository.ak47.GunBullet;
            EventSwitchGun?.Invoke(_model.Bullet);
        }
        if(weaponIndex == 2)//P90
        {
            _model.Bullet = _repository.plane007.GunBullet;
            
            EventSwitchGun?.Invoke(_model.Bullet);
        }
        
    }
}