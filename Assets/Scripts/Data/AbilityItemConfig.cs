using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AbilityItemConfig", menuName = "AbilityItemConfig")]
public class AbilityItemConfig : ScriptableObject
{
    [SerializeField]
    private ItemConfig _itemConfig;

    [SerializeField]
    private GameObject _view;

    [SerializeField]
    private AbilityType _abilityType;

    [SerializeField]
    private float _value;

    public int Id => _itemConfig._Id;

    public float Value => _value;

    public AbilityType AbilityType => _abilityType;

    public GameObject View => _view;

    public ItemConfig ItemConfig => _itemConfig;
}

public enum AbilityType
{
    None,
    Gun,
    Bomb
}
