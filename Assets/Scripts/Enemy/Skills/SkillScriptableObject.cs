using UnityEngine;

public class SkillScriptableObject : ScriptableObject
{
    public float Cooldown = 10f;
    public int Damage = 5;
    public int UnlockLevel = 1;

    public bool IsActivating;

    protected float UseTime;

    public virtual SkillScriptableObject ScaleUpForLevel(ScalingScriptableObject Scaling, int Level)
    {
        SkillScriptableObject scaledSkill = CreateInstance<SkillScriptableObject>();

        ScaleUpBaseValuesForLevel(scaledSkill, Scaling, Level);

        return scaledSkill;
    }

    protected virtual void ScaleUpBaseValuesForLevel(SkillScriptableObject Instance, ScalingScriptableObject Scaling, int Level)
    {
        Instance.name = name;

        Instance.Cooldown = Cooldown;
        Instance.Damage = Damage + Mathf.FloorToInt(Scaling.DamageCurve.Evaluate(Level));
        Instance.UnlockLevel = UnlockLevel;
    }

    public virtual void UseSkill(Enemy Enemy, Player Player)
    {
        IsActivating = true;
    }

    public virtual bool CanUseSkill(Enemy Enemy, Player Player, int Level)
    {
        return Level >= UnlockLevel;
    }
}
