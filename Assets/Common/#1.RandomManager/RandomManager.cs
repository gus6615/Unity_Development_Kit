using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �����÷��� ��Ҹ� ������ �� ����ϴ� �Ŵ���
/// </summary>
public class RandomManager
{
    /// <summary>
    /// Ȯ���� ���� true Ȥ�� false�� ��ȯ�ϴ� �Լ�
    /// </summary>
    /// <param name="percent">Ȯ��(0f ~ 1f)</param>
    public static bool GetRandFlag(float percent) => Random.value <= percent;


    /// <summary>
    /// Ȯ�� ��� ���� ����ġ�� ������ ���� ��ȯ�ϴ� �Լ�
    /// </summary>
    /// <param name="num">�⺻��</param>
    /// <param name="curve">Ȯ�� �</param>
    public static int GetRandWeightedNum(int num, AnimationCurve curve) => (int)(num * curve.Evaluate(Random.value));


    /// <summary>
    /// Ȯ��ǥ�� ���� Element�� ��ȯ�ϴ� �Լ�
    /// </summary>
    /// <param name="percents">Ȯ��ǥ(element: 0f ~ 1f)</param>
    public static int GetRandElement(params float[] percents)
    {
        float[] percents_copy = (float[])percents.Clone();
        float value = Random.value;

        // Ȯ�� �����͸� ���� ���·� ����
        for (int i = 1; i < percents_copy.Length; i++)
            percents_copy[i] += percents_copy[i - 1];

        // �ִ� ������ ���� value Ȯ��
        value *= percents_copy[percents_copy.Length - 1];

        // ���� üũ => ��÷ ��� ��ȯ
        for (int i = 1; i < percents_copy.Length; i++)
            if (percents_copy[i - 1] <= value && value < percents_copy[i])
                return i;
        return 0;
    }
}
