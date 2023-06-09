using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Player;
public class PlayerPresenter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public PlayerUseCase _usecase;
    [SerializeField] private PlayerView _view;
    [SerializeField] private TpsController _camera;
    [SerializeField] private Transform player;

    [SerializeField] private Enemy enemy;

    [SerializeField] private GunPresenter _gunPresenter;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        _usecase = new PlayerUseCase(gameManager.GetDataRepository());
        _usecase.GetTarget(player);
        _camera.EventMove = _usecase.Move;
        enemy.EventDamage = _view.Damage;
        _usecase.ChangeModel = _view.SynModel;
        _gunPresenter.Initialize();
        _usecase.SynModel();
    }
    

}
