using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " UpgradeItemConfigDataSource", menuName = " UpgradeItemConfigDataSource", order = 1)]
public class UpgradeItemConfigDataSource :ScriptableObject
{
   [SerializeField] private UpdateItemConfig [] _updateItemConfig;

   public UpdateItemConfig[] Config => _updateItemConfig;
}
