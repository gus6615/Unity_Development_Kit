using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireQuest : Quest
{
    public override string Title => $"{Target.QuestID}��(��) ����!";
    public override string Description => $"{Target.QuestID}��(��) {MaxQuantity}�� ȹ���Ͻÿ�.";
    public AcquireQuest(string id, IQuestTarget target, int maxQuantity) : base(id, QuestType.Acquire, target, maxQuantity)
    {

    }

    public override void GetReward()
    {
        Debug.Log($"'{Title}' ȹ�� ����Ʈ �Ϸ�. ������ �����մϴ�.");
    }
}