using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ObjectiveReward))]

public class ObjectiveRewardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ObjectiveReward t = target as ObjectiveReward;

        if (t.rewardType == RewardType.maxHealth || t.rewardType == RewardType.maxAmmo)
        {
            t.increaseRatio = EditorGUILayout.FloatField("IncreaseRatio", t.increaseRatio);
        }

        if (t.rewardType == RewardType.armor || t.rewardType == RewardType.reloadDelay)
        {
            t.decreaseRatio = EditorGUILayout.FloatField("DecreaseRatio", t.decreaseRatio);
        }

        if (t.rewardType == RewardType.destroyObject)
        {
            t.destroyObject = (GameObject)EditorGUILayout.ObjectField("DestroyObject", 
                t.destroyObject, typeof(GameObject), true);
        }
    }

}
