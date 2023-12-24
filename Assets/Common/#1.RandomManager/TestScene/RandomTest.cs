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
        Debug.Log($"´ÜÀÏ È®·ü({randPercent * 100}%) °á°ú: {success} ¼º°ø | {100 - success} ½ÇÆÐ");



        int[] successes = new int[randPercents.Length];
        for (int i = 0; i < 100; i++)
            successes[RandomManager.GetRandElement(randPercents)]++;

        Debug.Log($"º¹ÇÕ È®·ü °á°ú");
        for (int i = 0; i < randPercents.Length; i++)
            Debug.Log($"º¹ÇÕ È®·ü [È®·ü {randPercents[i] * 100}%] °á°ú: {successes[i]} µîÀå");



        float average = 0;
        for (int i = 0; i < 100; i++)
            average += RandomManager.GetRandWeightedNum(100, randCurve);
        average /= 100;
        Debug.Log($"·£´ý °¡ÁßÄ¡ °î¼± Æò±Õ: {average}");
    }
}
