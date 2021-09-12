﻿using TdFactory.Entities;
using TdFactory.System;
using UnityEngine;

namespace TdFactory.Planets.Placables
{
    public class GrassPlacement : Placement
    {
        private GameObject _sprite;
        
        public override void Initialize()
        {
            _sprite = new GameObject();
            _sprite.transform.parent = MainTile.transform;
            _sprite.transform.localPosition = Vector3.zero;
            _sprite.transform.localScale = Vector3.one;
            
            SpriteRenderer spriteRenderer = _sprite.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Tiles/Grass");

            float noise = Mathf.PerlinNoise(MainTile.Position.x / 125.53f, MainTile.Position.y / 125.53f);
            spriteRenderer.color = new Color(0.2f + noise * 0.7f, 0.4f + noise * 0.45f, 0.15f + noise * 0.1f);
        }

        public override void CleanUp()
        {
            Object.Destroy(_sprite);
            
            base.CleanUp();
        }

        public override void Interact(Interaction interaction)
        {
            interaction.Secondary<Player>(Build);
        }

        private void Build(Player player)
        {
            if (MainTile.Thing == null)
            {
                MainTile.SetThing<TreePlacement>();
            }
        }
    }
}