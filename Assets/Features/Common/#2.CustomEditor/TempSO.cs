using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TempSO", menuName = "Scriptable Object/TempSO")]
public class TempSO : ScriptableObject
{
    public static int attackRow = 5;
    public static int attackCol = 9;

    [SerializeField] private int id;
    public int ID => id;

    [SerializeField] private new string name;
    public string Name => name;

    [SerializeField] private Stat stat;
    public Stat Stat => stat;

    [SerializeField] private Action<int> attack;

    [SerializeField] [HideInInspector] private bool[] attackRange = new bool[attackRow * attackCol];
    public bool[] AttackRange => attackRange;
}

[System.Serializable]
public struct Stat
{
    public int Health;
    public int Mana;
    public int Power;
    public int Armor;
}
