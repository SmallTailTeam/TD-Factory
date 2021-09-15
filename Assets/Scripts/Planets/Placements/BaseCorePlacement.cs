using UnityEngine;

namespace TdFactory.Planets.Placements
{
    public class BaseCorePlacement : Placement
    {
        private GameObject _graphics;
        
        public override void Initialize()
        {
            _graphics = new GameObject();
            _graphics.transform.parent = ParentTile.transform;
            _graphics.transform.localPosition = Vector3.zero;

            SpriteRenderer spriteRenderer = _graphics.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Tiles/BaseCore");
            spriteRenderer.sortingOrder = 1;
        }

        public override void CleanUp()
        {
            Object.Destroy(_graphics);
        }
    }
}