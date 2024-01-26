using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 데이터는 Scriptable Object로 관리됩니다.
/// 보통 읽기 전용이며, 게임 진행에 필요한 요소들의 정보입니다.
/// </summary>
public class DataManager : MonoBehaviour
{
    /// <summary>
    /// 임시 데이터(SO 파일)
    /// </summary>
    public List<TempData> tempDatas;

    public void Init()
    {
        tempDatas = new List<TempData>();
        tempDatas.AddRange(GameManager.Resource.LoadAll<TempData>("TempDatas"));
    }
}
