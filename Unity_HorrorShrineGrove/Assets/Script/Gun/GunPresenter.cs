using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPresenter : MonoBehaviour
{
    [SerializeField] private m500Script _m500;
    [SerializeField] private PlayerPresenter _playerPresenter;
    void Start()
    {
        _m500.SetDataRepository();
        
        _m500.SynModel();
    }
    public void Initialize()
    {
        _m500.EventBulletView = _playerPresenter._usecase.SynModel;
    }

}
