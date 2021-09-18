using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using TdFactory.Entities;
using TdFactory.System;
using TdFactory.UI.Windows;
using UnityEngine;

namespace TdFactory.Planets.Placements.Defenses
{
    public class PrimitiveTurretPlacement : Placement, IProgrammable
    {
        public string Code { get; set; }
        
        private WindowManager _windowManager;
        
        private GameObject _base;
        private GameObject _head;
        private IdeWindow _ideWindow;
        private float _time;

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

        public override async void Tick()
        {
            _time += Time.deltaTime;
            
            if (_time > 1f && !string.IsNullOrWhiteSpace(Code) && _ideWindow == null)
            {
                await CSharpScript.EvaluateAsync(Code, ScriptOptions.Default
                    .WithImports(
                        "UnityEngine",
                        "TdFactory.Entities",
                        "TdFactory.System.Items")
                    .AddReferences(
                        typeof(Debug).Assembly,
                        typeof(PrimitiveTurretPlacement).Assembly));

                _time = 0f;
            }
        }

        public override void Interact(Interaction interaction)
        {
            interaction.Primary<Player>(Open);
        }

        private void Open(Player player)
        {
            if (_ideWindow != null)
            {
                _ideWindow.Close();
            }
            else
            {
                _ideWindow = _windowManager.Create<IdeWindow>("IDE");
                _ideWindow.LinkTo(this);
            }
        }
    }
}