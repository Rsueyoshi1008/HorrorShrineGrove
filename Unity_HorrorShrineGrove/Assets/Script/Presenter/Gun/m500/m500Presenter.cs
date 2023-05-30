using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m500Presenter : MonoBehaviour
{
    [SerializeField] private m500Script _m500;
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private GunSwitchPresenter _switchPresenter;
    public void Initialize()
    {
        _m500.SetDataRepository();
        
        _m500.SynModel();
        _m500.EventBulletView = _playerPresenter._usecase.SynModel;
        _switchPresenter.Initialize();
    }

}
