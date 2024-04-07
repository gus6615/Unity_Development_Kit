using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireQuest : Quest
{
    public override string Title => $"{Target.QuestID}을(를) 얻자!";
    public override string Description => $"{Target.QuestID}을(를) {MaxQuantity}개 획득하시오.";
    public AcquireQuest(string id, IQuestTarget target, int maxQuantity) : base(id, QuestType.Acquire, target, maxQuantity)
    {

    }

    public override void GetReward()
    {
        Debug.Log($"'{Title}' 획득 퀘스트 완료. 보상을 지급합니다.");
    }
}