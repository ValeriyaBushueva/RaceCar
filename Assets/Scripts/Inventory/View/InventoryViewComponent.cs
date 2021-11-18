using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.View
{
    public class InventoryViewComponent : MonoBehaviour, IInventoryView
    {
        [SerializeField] private InventorySpotView _itemSpotPrefab;
        [SerializeField] private Transform _contentContainer;
        [SerializeField] private Button _visibilityButton;

        private void Awake()
        {
            _visibilityButton.onClick.AddListener(ShowHide);
        }

        private void OnDestroy()
        {
            _visibilityButton.onClick.RemoveListener(ShowHide);
        }

        private void ShowHide()
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }

        public void Display(IReadOnlyList<IItem> items)
        {
            foreach (var item in items)
            {
                InventorySpotView spot = Instantiate(_itemSpotPrefab, _contentContainer);

                spot.ItemSprite = item.ItemInfo.Sprite;
            }
        }
    }
}