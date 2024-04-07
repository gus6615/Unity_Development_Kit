using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ӽ� Scriptable Object ������ Ŭ����
/// </summary>
[CreateAssetMenu(fileName = "JemSO", menuName = "Scriptable Object/JemSO")]
public class JemSO : ScriptableObject
{
    [SerializeField]
    private string _name;
    public string Name => _name;

    [SerializeField]
    private string info;
    public string Info => info;

    [SerializeField]
    private long price;
    public long Price => price;

    [SerializeField]
    private JemStat stat;
    public JemStat Stat => stat;

    public void Init(string name, string info, long price, JemStat stat)
    {
        this._name = name;
        this.info = info;
        this.price = price;
        this.stat = stat;
        
        Show();
    }

    public void Show() => Debug.Log($"{Name} | {Price} | {typeof(JemQuality).GetEnumName(stat.Quality)}");
}

[System.Serializable]
public struct JemStat
{
    public JemQuality Quality;

    public void Init(JemQuality quality)
    {
        this.Quality = quality;
    }

    public void Init (string qualityStr)
    {
        this.Quality = ParseQualityFromString(qualityStr);
    }

    private JemQuality ParseQualityFromString(string qualityStr)
    {
        switch (qualityStr)
        {
            case "���": return JemQuality.Normal;
            case "����": return JemQuality.Rare;
            case "����": return JemQuality.Epic;
            case "����ũ": return JemQuality.Unique;
            case "�����帮": return JemQuality.Legendary;
        }

        Debug.LogWarning("Jem Quality is not parsed!");
        return JemQuality.None;
    }
}

public enum JemQuality
{
    None,
    Normal,
    Rare,
    Epic,
    Unique,
    Legendary
}