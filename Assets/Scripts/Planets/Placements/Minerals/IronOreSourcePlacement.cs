using TdFactory.Entities;
using TdFactory.System;
using TdFactory.System.Items;
using UnityEngine;

namespace TdFactory.Planets.Placements.Minerals
{
    public class IronOreSourcePlacement : Placement
    {
        private GameObject _sprite;
        private int _richness = Random.Range(1000, 3000);
        
        public override void Initialize()
        {
            _sprite = new GameObject();
            _sprite.transform.parent = ParentTile.transform;
            _sprite.transform.localPosition = Vector3.zero;
            _sprite.transform.localScale = Vector3.one + new Vector3(Random.Range(0.2f, 0.6f), Random.Range(0.2f, 0.6f), 0);

            SpriteRenderer spriteRenderer = _sprite.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Tiles/IronOreSource");
            spriteRenderer.sortingOrder = 1;
        }

        public override void CleanUp()
        {
            Object.Destroy(_sprite);
            
            base.CleanUp();
        }

        public override void Interact(Interaction interaction)
        {
            interaction.Secondary<Player>(Collect);
        }

        private void Collect(Player player)
        {
            player.Inventory.AddItem(ItemDefs.Find("TdFactory/IronOre"));
            _richness--;

            if (_richness <= 0)
            {
                CleanUp();
            }
        }
    }
}