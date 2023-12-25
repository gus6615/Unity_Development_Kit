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
            if (RandomManager.GetFlag(randPercent))
                success++;
        Debug.Log($"���� Ȯ��({randPercent * 100}%) ���: {success} ���� | {100 - success} ����");



        int[] successes = new int[randPercents.Length];
        for (int i = 0; i < 100; i++)
            successes[RandomManager.GetElement(randPercents)]++;

        Debug.Log($"���� Ȯ�� ���");
        for (int i = 0; i < randPercents.Length; i++)
            Debug.Log($"���� Ȯ�� [Ȯ�� {randPercents[i] * 100}%] ���: {successes[i]} ����");



        float average = 0;
        for (int i = 0; i < 100; i++)
            average += RandomManager.GetWeightedNum(100, randCurve);
        average /= 100;
        Debug.Log($"���� ����ġ � ���: {average}");



        for (int i = 0; i < 100; i++)
        {
            int[] temps = RandomManager.Shuffle(new int[] { 1, 2, 3, 4, 5 });
            foreach (var item in temps)
                Debug.Log(item);
            Debug.Log($"���� ���� {i} ��° ---------------------------");
        }



        for (int i = 0; i < 100; i++)
        {
            int numToSelect = Random.Range(0, 5);
            List<int> temps = RandomManager.ChooseSet(new List<int>(new int[] { 1, 2, 3, 4, 5 }), numToSelect);
            foreach (var item in temps)
                Debug.Log(item);
            Debug.Log($"�ߺ� ���� {numToSelect} �� �̱� {i} ��° ---------------------------");
        }
    }
}
