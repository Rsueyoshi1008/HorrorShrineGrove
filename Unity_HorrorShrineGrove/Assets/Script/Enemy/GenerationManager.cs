using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    [SerializeField] private List<EnemyGeneration> _generation;
    
    public void Generation()
    {
        for(var i = 0; i < _generation.Count; i++)
        {
            _generation[i].EnemyDefeated();
        }
    }

    
}
