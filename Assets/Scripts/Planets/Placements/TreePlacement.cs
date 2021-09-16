using TdFactory.Entities;
using TdFactory.System.Items;
using TdFactory.System;
using UnityEngine;

namespace TdFactory.Planets.Placements
{
    public class TreePlacement : Placement
    {
        private GameObject _sprite;
        
        public override void Initialize()
        {
            _sprite = new GameObject();
            _sprite.transform.parent = ParentTile.transform;
            _sprite.transform.localPosition = new Vector3(-0.2f, 0.5f) + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0f);
            _sprite.transform.localScale = Vector3.one * 1.3f + new Vector3(Random.Range(0.2f, 0.6f), Random.Range(0.2f, 0.6f), 0);

            SpriteRenderer spriteRenderer = _sprite.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>($"Tiles/Tree_0{Random.Range(1, 5)}");
            spriteRenderer.sortingOrder = 1;
        }

        public override void CleanUp()
        {
            Object.Destroy(_sprite);
            
            base.CleanUp();
        }

        public override void Interact(Interaction interaction)
        {
            interaction.Secondary<Player>(Harvest);
        }

        private void Harvest(Player player)
        {
            player.Inventory.AddItem(ItemDefs.Find("TdFactory/Planks"));
            CleanUp();
        }
    }
}