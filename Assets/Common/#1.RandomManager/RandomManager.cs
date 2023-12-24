using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 랜덤 게임플레이 요소를 구현할 때 사용하는 매니저
/// </summary>
public class RandomManager
{
    /// <summary>
    /// 확률에 따라 true 혹은 false를 반환하는 함수
    /// </summary>
    /// <param name="percent">확률(0f ~ 1f)</param>
    public static bool GetRandFlag(float percent) => Random.value <= percent;


    /// <summary>
    /// 확률 곡선에 따른 가중치가 곱해진 값을 반환하는 함수
    /// </summary>
    /// <param name="num">기본값</param>
    /// <param name="curve">확률 곡선</param>
    public static int GetRandWeightedNum(int num, AnimationCurve curve) => (int)(num * curve.Evaluate(Random.value));


    /// <summary>
    /// 확률표에 따라 Element를 반환하는 함수
    /// </summary>
    /// <param name="percents">확률표(element: 0f ~ 1f)</param>
    public static int GetRandElement(params float[] percents)
    {
        float[] percents_copy = (float[])percents.Clone();
        float value = Random.value;

        // 확률 데이터를 범위 형태로 변경
        for (int i = 1; i < percents_copy.Length; i++)
            percents_copy[i] += percents_copy[i - 1];

        // 최대 범위에 따라 value 확장
        value *= percents_copy[percents_copy.Length - 1];

        // 범위 체크 => 당첨 요소 반환
        for (int i = 1; i < percents_copy.Length; i++)
            if (percents_copy[i - 1] <= value && value < percents_copy[i])
                return i;
        return 0;
    }
}
