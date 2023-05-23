using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun : MonoBehaviour
{
    [SerializeField] private GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        gun.SetActive(false);
        Debug.Log(gun.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
