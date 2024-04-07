using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MonsterData
{
    public string ID;
    public string Name;
    public string Description;

    public MonsterData(string id, string name, string description)
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
    }
}

public abstract class Monster
{
    public MonsterData Data;

    public Monster(MonsterData data)
    {
        this.Data = new MonsterData();
        this.Data.ID = data.ID;
        this.Data.Name = data.Name;
        this.Data.Description = data.Description;
    }
}

public class Slime : Monster, IQuestTarget
{
    public Slime(MonsterData data) : base(data)
    {

    }

    string IQuestTarget.QuestID { get => Data.ID; }

    public bool CheckFullFill()
    {
        throw new System.NotImplementedException();
    }
}

public class Wolf : Monster, IQuestTarget
{
    public Wolf(MonsterData data) : base(data)
    {

    }

    string IQuestTarget.QuestID { get => Data.ID; }

    public bool CheckFullFill()
    {
        throw new System.NotImplementedException();
    }
}

public class Golem : Monster, IQuestTarget
{
    public Golem(MonsterData data) : base(data)
    {

    }

    string IQuestTarget.QuestID { get => Data.ID; }

    public bool CheckFullFill()
    {
        throw new System.NotImplementedException();
    }
}
