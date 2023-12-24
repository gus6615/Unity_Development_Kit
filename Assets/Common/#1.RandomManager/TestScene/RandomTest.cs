using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTest : MonoBehaviour
{
    [SerializeField]
    private float randPercent;

    [SerializeField]
    private float[] randPercents;

    [SerializeField]
    private AnimationCurve randCurve;

    // Start is called before the first frame update
    void Start()
    {
        int success = 0;
        for (int i = 0; i < 100; i++)
            if (RandomManager.GetRandFlag(randPercent))
                success++;
        Debug.Log($"���� Ȯ��({randPercent * 100}%) ���: {success} ���� | {100 - success} ����");



        int[] successes = new int[randPercents.Length];
        for (int i = 0; i < 100; i++)
            successes[RandomManager.GetRandElement(randPercents)]++;

        Debug.Log($"���� Ȯ�� ���");
        for (int i = 0; i < randPercents.Length; i++)
            Debug.Log($"���� Ȯ�� [Ȯ�� {randPercents[i] * 100}%] ���: {successes[i]} ����");



        float average = 0;
        for (int i = 0; i < 100; i++)
            average += RandomManager.GetRandWeightedNum(100, randCurve);
        average /= 100;
        Debug.Log($"���� ����ġ � ���: {average}");
    }
}
