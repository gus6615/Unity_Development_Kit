using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuestTarget
{
    public string QuestID { get; }
    public bool CheckFullFill();
}

public enum QuestType
{
    Acquire,
    Kill,
}

public abstract class Quest
{
    public QuestType Type;
    public IQuestTarget Target;
    public string ID;
    public abstract string Title { get; }
    public abstract string Description { get; }

    public int MaxQuantity;
    public int CurrentQuantity;

    public Quest(string id, QuestType type, IQuestTarget target, int maxQuantity)
    {
        this.ID = id;
        this.Type = type;
        this.Target = target;
        this.MaxQuantity = maxQuantity;
        this.CurrentQuantity = 0;
    }

    public virtual void IncrementQuantity()
    {
        if (CurrentQuantity < MaxQuantity)
            CurrentQuantity++;
    }

    public virtual bool IsCompleted()
    {
        return CurrentQuantity == MaxQuantity;
    }

    public virtual bool CheckProgress(IQuestTarget current)
    {
        return current.QuestID == Target.QuestID;
    }

    public abstract void GetReward();
}
