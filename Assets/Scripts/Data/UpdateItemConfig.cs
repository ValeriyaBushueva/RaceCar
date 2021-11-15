using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " Upgrade Item", menuName = " Upgrade Item", order = 1)]
public class UpdateItemConfig : ScriptableObject
{
    [SerializeField] private ItemConfig _itemConfig;
    [SerializeField] private UpgradeType _upgradeType;
    [SerializeField] private float _valueUpgrade;


    public int Id => _itemConfig._Id;

    public UpgradeType UpgradeType => _upgradeType;

    public float ValueUpgrade => _valueUpgrade;
}

public enum UpgradeType
{
    None,
    Speed,
    Control
}
