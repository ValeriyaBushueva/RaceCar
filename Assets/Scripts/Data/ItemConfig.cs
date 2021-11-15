using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class ItemConfig :ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _title;
    
    public string Title => _title;
    public int _Id => _id;
}
