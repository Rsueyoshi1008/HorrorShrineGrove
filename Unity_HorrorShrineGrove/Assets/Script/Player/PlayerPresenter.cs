using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Player;
public class PlayerPresenter : MonoBehaviour
{
    
    [SerializeField] private PlayerView _view;
    [SerializeField] private PlayerUseCase _usecase;
    void Start()
    {
        


        _view.Initialization();
        
    }

}
