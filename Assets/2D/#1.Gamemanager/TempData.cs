using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ӽ� Scriptable Object ������ Ŭ����
/// </summary>
[CreateAssetMenu(fileName = "TempData", menuName = "Scriptable Object/TempData")]
public class TempData : ScriptableObject
{
    [SerializeField]
    private string id;
    public string ID => id;

    [SerializeField]
    private string pw;
    public string PW => pw;

    [SerializeField]
    private TempStructure tempStructure;
    public TempStructure TempStructure => tempStructure;

    public void Show() => Debug.Log($"ID: {id} | PW: {pw}");
}

[System.Serializable]
public struct TempStructure
{
    public List<int> elements;
}