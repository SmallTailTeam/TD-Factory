using UnityEngine;

namespace TdFactory.Planets.Placements.Defenses
{
    public class PrimitiveTurretPlacement : Placement
    {
        private GameObject _base;
        private GameObject _head;

        public override void Initialize()
        {
           CreateBase();
           CreateHead();
        }

        private void CreateBase()
        {
            _base = new GameObject();
            _base.transform.parent = ParentTile.transform;
            _base.transform.localPosition = Vector3.zero;
            _base.transform.localScale = Vector3.one;

            SpriteRenderer spriteRenderer = _base.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Tiles/PrimitiveTurretBase");
            spriteRenderer.sortingOrder = 1;
        }

        private void CreateHead()
        {
            _head = new GameObject();
            _head.transform.parent = ParentTile.transform;
            _head.transform.localPosition = Vector3.zero;
            _head.transform.localScale = Vector3.one;

            SpriteRenderer spriteRenderer = _head.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Tiles/PrimitiveTurretHead");
            spriteRenderer.sortingOrder = 2;
        }
        
        public override void CleanUp()
        {
            Object.Destroy(_base);
            Object.Destroy(_head);
            
            base.CleanUp();
        }
    }
}