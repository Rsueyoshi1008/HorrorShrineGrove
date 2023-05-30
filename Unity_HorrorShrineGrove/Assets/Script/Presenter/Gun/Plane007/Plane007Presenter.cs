using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane007Presenter : MonoBehaviour
{
    [SerializeField] private P90Script _plane007UseCase;
    [SerializeField] private PlayerPresenter _playerPresenter;
    public void Initialize()
    {
        _plane007UseCase.SetDataRepository();
        _plane007UseCase.EventBulletView = _playerPresenter._usecase.SynModel;
        
        _plane007UseCase.SynModel();
    }
}
