using UnityEngine;

namespace TdFactory.Planets.Placables
{
    public class WorkbenchPlacement : Placement
    {
        private GameObject _graphics;
        
        public override void Initialize()
        {
            _graphics = new GameObject();
            _graphics.transform.localPosition = Vector3.zero;

            SpriteRenderer spriteRenderer = _graphics.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Tiles/Workbench");
        }

        public override void CleanUp()
        {
            Object.Destroy(_graphics);
        }
    }
}