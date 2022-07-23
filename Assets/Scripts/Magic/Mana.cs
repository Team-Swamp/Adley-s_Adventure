using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mana : MonoBehaviour
{
    [Header("Event Variables")]
    [SerializeField] private UnityEvent onFull = new UnityEvent();
    [SerializeField] private UnityEvent onEmpty = new UnityEvent();
    
    [SerializeField] private float maxMana;
    [SerializeField] private float minMana;

    private float _mana;
    private void Start()
    {
        _mana = maxMana;
    }

    /// <summary>
    /// Try to use given amount of mana.
    /// </summary>
    /// <param name="expendedMana">The amount of mana to subtract from the mana pool.</param>
    /// <returns>True if succeeded, false otherwise.</returns>
    public bool UseMana(float expendedMana)
    {
        if (_mana - expendedMana < minMana) return false;

        _mana -= expendedMana;
        
        if(_mana == minMana) onEmpty.Invoke();
        return true;
    }

    /// <summary>
    /// Add given amount of mana to pool.
    /// </summary>
    /// <param name="addedMana">Amount of mana to add.</param>
    public void AddMana(float addedMana)
    {
        // if the mana pool is already at max there is no need to add to it. (Prevents unnecessary invokes of the onFull event.)
        if (_mana == maxMana) return;
        
        _mana = Mathf.Clamp(_mana + addedMana, minMana, maxMana);
        
        if (_mana == maxMana) onFull.Invoke();
    }
}
