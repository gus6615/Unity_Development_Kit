using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuest : Quest
{
    public override string Title => $"{Target.QuestID}을(를) 잡아라!";
    public override string Description => $"{Target.QuestID}을(를) {MaxQuantity}개 처치하시오.";

    public KillQuest(string id, IQuestTarget target, int maxQuantity) : base(id, QuestType.Kill, target, maxQuantity)
    {

    }

    public override void GetReward()
    {
        Debug.Log($"'{Target}' 처치 퀘스트 완료. 보상을 지급합니다.");
    }
}
