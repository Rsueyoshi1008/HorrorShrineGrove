using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManagerPresenter : MonoBehaviour
{
    [SerializeField] private m500Presenter _m500;
    [SerializeField] private AK47Presenter _ak47;
    [SerializeField] private Plane007Presenter _plane007;
    // Start is called before the first frame update
    public void Initialize()
    {
        _m500.Initialize();
        _ak47.Initialize();
        _plane007.Initialize();
    }
}
