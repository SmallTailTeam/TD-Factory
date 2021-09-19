using System;
using System.Reflection;
using TdFactory.Entities;
using TdFactory.System;
using TdFactory.UI.Windows;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TdFactory.Planets.Placements.Defenses
{
    public class PrimitiveTurretPlacement : Placement
    {
        private WindowManager _windowManager;
        
        private GameObject _base;
        private GameObject _head;
        private IdeWindow _ideWindow;
        private Turret _turret;

        public override void Initialize()
        {
            _windowManager = Object.FindObjectOfType<WindowManager>();
            
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

        public override void PhysicsTick()
        {
            if (_ideWindow != null && !CanOpen())
            {
                _ideWindow.Close();
            }
        }
        
        public override void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _ideWindow != null)
            {
                _ideWindow.Close();
            }

            if (_turret != null)
            {
                _turret.Tick();
                _head.transform.rotation = Quaternion.Euler(0f, 0f, _turret.Angle);
            }
        }
        
        public override void Interact(Interaction interaction)
        {
            interaction.Primary<Player>(Toggle, CanOpen);
        }

        private void Toggle(Player player)
        {
            if (_ideWindow != null)
            {
                _ideWindow.Close();
            }
            else
            {
                _ideWindow = _windowManager.Create<IdeWindow>("IDE");
                _ideWindow.SetTitle("Primitive turret");
                _ideWindow.Compiled += Compiled;
                _ideWindow.Closed += () => player.EnableMovement = true;
                player.EnableMovement = false;
            }
        }

        private void Compiled(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (Activator.CreateInstance(type) is Turret turret)
                {
                    _turret = turret;
                }
            }
        }
        
        private bool CanOpen()
        {
            return Vector3.Distance(Player.Me.transform.position, ParentTile.transform.position) <= Tile.Distance(3);
        }
    }

    public class Turret
    {
        public float Angle;
        
        public virtual void Tick() {}
    }
}