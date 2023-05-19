using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Player;
public class PlayerPresenter : MonoBehaviour
{
    
    [SerializeField] private PlayerView _view;
    [SerializeField] private PlayerUseCase _useCase;

    [SerializeField] private TpsController _camera;
    void Start()
    {
        _view.EventDebugTest = _useCase.Test;
        _camera.EventPlayer = _useCase.Move;

        _view.Initialization();
        
    }

}
