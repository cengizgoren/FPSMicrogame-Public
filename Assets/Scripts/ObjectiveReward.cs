using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveReward : MonoBehaviour
{
    public RewardType rewardType;

    [HideInInspector]
    [Range(0f,3f)]
    public float increaseRatio;

    [HideInInspector]
    [Range(0f,1f)]
    public float decreaseRatio;

    [HideInInspector]
    public GameObject destroyObject;

    GameObject player;
    WeaponController weapon;

    public void ApplyReward()
    {
        player = GameObject.Find("Player");
        weapon = player.GetComponent<PlayerWeaponsManager>().weaponParentSocket.
            GetComponentInChildren<WeaponController>();

        switch (rewardType)
        {
            case RewardType.maxHealth:
                {
                    player.GetComponent<Health>().maxHealth *= (1 + increaseRatio);
                    break;
                }
            case RewardType.armor:
                {
                    player.GetComponent<Damageable>().damageMultiplier *= (1 - decreaseRatio);
                    break;
                }
            case RewardType.maxAmmo:
                {
                    weapon.maxAmmo *= (1 + increaseRatio);
                    break;
                }
            case RewardType.reloadDelay:
                {
                    weapon.ammoReloadDelay *= (1 - decreaseRatio);
                    break;
                }
            case RewardType.destroyObject:
                {
                    Destroy(destroyObject);
                    break;
                }
        }
    }
}

public enum RewardType
{
    maxHealth,maxAmmo,armor,reloadDelay, destroyObject
}