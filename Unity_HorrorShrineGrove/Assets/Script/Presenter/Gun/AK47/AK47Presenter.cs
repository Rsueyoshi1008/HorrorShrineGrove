using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Presenter : MonoBehaviour
{
    [SerializeField] private AKScript _ak47UseCase;
    [SerializeField] private PlayerPresenter _playerPresenter;
    public void Initialize()
    {
        _ak47UseCase.SetDataRepository();
        
        _ak47UseCase.EventBulletView = _playerPresenter._usecase.SynModel;
        _ak47UseCase.SynModel();
    }
    
}
