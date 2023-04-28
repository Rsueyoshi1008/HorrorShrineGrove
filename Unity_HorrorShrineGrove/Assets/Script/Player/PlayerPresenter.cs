using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Player;
public class PlayerPresenter : MonoBehaviour
{
    
    [SerializeField] private PlayerView _view;
    private PlayerUseCase _usecase;
    void Start()
    {
        _usecase = new PlayerUseCase();
        
        _view.EventMove = _usecase.Move;
        
    }

}
