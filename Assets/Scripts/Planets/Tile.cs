using TdFactory.System;
using UnityEngine;

namespace TdFactory.Planets
{
    public class Tile : MonoBehaviour, IInteractable
    {
        public World World { get; set; }
        public Vector2Int Position { get; set; }
        public Placement Ground => _ground;
        public Placement Thing => _thing;
        public Placement Ceiling => _ceiling;
        
        private Placement _ground;
        private Placement _thing;
        private Placement _ceiling;

        public void SetGround<T>() where T : Placement, new()
        {
            SetSomething<T>(ref _ground);
            _ground.CleanedUp += () => _ground = null;
        }

        public void SetThing<T>() where T : Placement, new()
        {
            SetSomething<T>(ref _thing);
            _thing.CleanedUp += () => _thing = null;
        }

        public void SetCeiling<T>() where T : Placement, new()
        {
            SetSomething<T>(ref _ceiling);
            _ceiling.CleanedUp += () => _ceiling = null;
        }

        private void SetSomething<T>(ref Placement place) where T : Placement, new()
        {
            place?.CleanUp();

            place = new T();
            place.ParentTile = this;
            
            place.Initialize();
        }

        private void FixedUpdate()
        {
            _ground?.PhysicsTick();
            _thing?.PhysicsTick();
            _ceiling?.PhysicsTick();
        }

        private void Update()
        {
            _ground?.Tick();
            _thing?.Tick();
            _ceiling?.Tick();
        }

        public void Interact(Interaction interaction)
        {
            InteractWithSomething(interaction, _ground);
            InteractWithSomething(interaction, _thing);
            InteractWithSomething(interaction, _ceiling);
        }

        private void InteractWithSomething(Interaction interaction, Placement placement)
        {
            if (placement != null)
            {
                placement.Interact(interaction);
            }
        }

        public static float Distance(int tileCount)
        {
            return tileCount * World.TILE_SIZE;
        }
    }
}