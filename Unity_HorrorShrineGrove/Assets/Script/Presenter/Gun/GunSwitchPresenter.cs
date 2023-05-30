using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitchPresenter : MonoBehaviour
{
    [SerializeField] private GunSwitch _useCase;

    [SerializeField] private PlayerPresenter _playerPresenter;
    public void Initialize()
    {
        _useCase.SetDataRepository();
        _useCase.EventSwitchGun = _playerPresenter._usecase.GetGunModel;
    }
}
