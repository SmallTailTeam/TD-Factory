using System;
using TdFactory.Planets;
using TdFactory.System.Items;
using TdFactory.System;
using UnityEngine;

namespace TdFactory.Entities
{
    public class Player : Entity
    {
        public static Player Me;
        
        public Action<ItemStack> HeldItemChanged { get; set; }

        public Inventory Inventory = new Inventory(20);
        public ItemStack HeldItem
        {
            get => _heldItem;
            set
            {
                _heldItem = value;
                HeldItemChanged?.Invoke(value);
            }
        }

        public bool EnableMovement { get; set; }

        [SerializeField] private float _movementSpeed;
        
        private ItemStack _heldItem;

        private void Awake()
        {
            EnableMovement = true;
            
            Me = this;
            Inventory.AddItem(ItemDefs.Find("TdFactory/PrimitiveTurret"));
        }

        private void Update()
        {
            Move();
            Interact();
            Build();
        }

        private void Move()
        {
            if (!EnableMovement)
            {
                return;
            }
            
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            transform.position += new Vector3(horizontal, vertical).normalized * _movementSpeed * Time.deltaTime;
        }

        private void Interact()
        {
            Interaction interaction = Interaction.Identity;
            
            if (Input.GetMouseButtonDown(0))
            {
                interaction = Interaction.Primary(this);
            }
            if (Input.GetMouseButtonDown(1))
            {
                interaction = Interaction.Secondary(this);
            }

            if (interaction != Interaction.Identity)
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);

                if (hit.collider.transform != null)
                {
                    MonoBehaviour[] components = hit.collider.transform.GetComponents<MonoBehaviour>();

                    foreach (MonoBehaviour component in components)
                    {
                        if (component is IInteractable interactable)
                        {
                            interactable.Interact(interaction);
                        }
                    }
                }
            }
        }
        
        private void Build()
        {
            if (Input.GetMouseButtonDown(1) && HeldItem is {Item: IBuildable buildable})
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Tile tile = World.Current.GetTile(point);
                    
                if (tile != null && tile.Thing == null)
                {
                    buildable.Build(tile);
                    Inventory.RemoveItem(HeldItem.Item);
                }
            }
        }
    }
}