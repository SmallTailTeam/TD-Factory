using TdFactory.Entities;
using TdFactory.System;
using TdFactory.UI.Windows;
using UnityEngine;

namespace TdFactory.Planets.Placements
{
    public class WorkbenchPlacement : Placement
    {
        private WindowManager _windowManager;
        
        private GameObject _graphics;
        private WorkbenchWindow _craftingWindow;
        
        public override void Initialize()
        {
            _windowManager = Object.FindObjectOfType<WindowManager>();
            
            _graphics = new GameObject();
            _graphics.transform.parent = ParentTile.transform;
            _graphics.transform.localPosition = Vector3.zero;
            _graphics.transform.localScale = Vector3.one;

            SpriteRenderer spriteRenderer = _graphics.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Tiles/Workbench");
            spriteRenderer.sortingOrder = 1;
        }

        public override void CleanUp()
        {
            Object.Destroy(_graphics);
            
            base.CleanUp();
        }

        public override void PhysicsTick()
        {
            if (_craftingWindow != null && !CanOpen())
            {
                _craftingWindow.Close();
            }
        }

        public override void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _craftingWindow != null)
            {
                _craftingWindow.Close();
            }
        }

        public override void Interact(Interaction interaction)
        {
            interaction.Primary<Player>(Open, CanOpen);
        }

        private bool CanOpen()
        {
            return Vector3.Distance(Player.Me.transform.position, ParentTile.transform.position) <= Tile.Distance(3);
        }

        private void Open(Player player)
        {
            if (_craftingWindow != null)
            {
                _craftingWindow.Close();
            }
            else
            {
                _craftingWindow = _windowManager.Create<WorkbenchWindow>("Workbench");
            }
        }
    }
}