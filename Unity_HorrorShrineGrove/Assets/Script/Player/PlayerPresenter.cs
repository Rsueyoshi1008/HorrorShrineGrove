using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Player;
public class PlayerPresenter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private PlayerUseCase _usecase;
    void Start()
    {
        _usecase = new PlayerUseCase(gameManager.GetDataRepository());

        //_usecase.ChangeModel = 


        _usecase.SynModel();
    }
    

}
