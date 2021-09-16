using UnityEngine;

namespace TdFactory.Planets.Placements.Defenses
{
    public class WoodenWallPlacement : Placement
    {
        private GameObject _graphics;

        public override void Initialize()
        {
            _graphics = new GameObject();
            _graphics.transform.parent = ParentTile.transform;
            _graphics.transform.localPosition = Vector3.zero;
            _graphics.transform.localScale = Vector3.one;

            SpriteRenderer spriteRenderer = _graphics.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Items/WoodenWall");
            spriteRenderer.sortingOrder = 1;
        }

        public override void CleanUp()
        {
            Object.Destroy(_graphics);
            
            base.CleanUp();
        }
    }
}