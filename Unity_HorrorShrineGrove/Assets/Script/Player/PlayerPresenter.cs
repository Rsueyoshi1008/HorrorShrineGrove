using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Player;
public class PlayerPresenter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private PlayerUseCase _usecase;
    [SerializeField] private TpsController _camera;
    [SerializeField] private Transform player;

    [SerializeField] private Enemy enemy;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        _usecase = new PlayerUseCase(gameManager.GetDataRepository());
        _usecase.GetTarget(player);
        _camera.EventMove = _usecase.Move;
        enemy.EventDamage = _usecase.Damage;
        //_usecase.ChangeScene = 

        _usecase.SynModel();
    }
    

}
