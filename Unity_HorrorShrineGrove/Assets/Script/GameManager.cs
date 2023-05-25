using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Repository;
public class GameManager : MonoBehaviour
{
    private static DataRepository _dataRepository;
    public DataRepository GetDataRepository()
    {
        if (_dataRepository == null)
        {
            _dataRepository = new DataRepository();
        }
        return _dataRepository;
    }
}
