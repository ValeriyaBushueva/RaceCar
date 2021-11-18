using UnityEngine;
using UnityEngine.UI;

namespace Inventory.View
{
    public class InventorySpotView : MonoBehaviour
    {
        [SerializeField] private Image item;

        public  Sprite ItemSprite
        {
            get => item.sprite;
            set => item.sprite = value;
        }
    }
}