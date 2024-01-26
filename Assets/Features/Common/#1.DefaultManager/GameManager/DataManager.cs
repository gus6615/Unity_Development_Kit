using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ʹ� Scriptable Object�� �����˴ϴ�.
/// ���� �б� �����̸�, ���� ���࿡ �ʿ��� ��ҵ��� �����Դϴ�.
/// </summary>
public class DataManager : MonoBehaviour
{
    /// <summary>
    /// �ӽ� ������(SO ����)
    /// </summary>
    public List<TempData> tempDatas;

    public void Init()
    {
        tempDatas = new List<TempData>();
        tempDatas.AddRange(GameManager.Resource.LoadAll<TempData>("TempDatas"));
    }
}
