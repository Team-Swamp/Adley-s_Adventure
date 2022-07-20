using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] private float maxMana;

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
    /// <example>
    /// <code>
    /// bool succeeded = UseMana(50f);
    /// if (!succeeded) return; // There wasn't enough mana.
    /// // Use magic
    /// </code>
    /// </example>
    public bool UseMana(float expendedMana)
    {
        if (_mana - expendedMana < 0f) return false;

        _mana -= expendedMana;
        return true;
    }

    /// <summary>
    /// Add given amount of mana to pool.
    /// </summary>
    /// <param name="addedMana">Amount of mana to add.</param>
    public void AddMana(float addedMana)
    {
        _mana = Mathf.Clamp(addedMana, 0f, maxMana);
    }
}
