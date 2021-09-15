using System;
using TdFactory.System.Items;
using TdFactory.System;
using UnityEngine;

namespace TdFactory.Entities
{
    public class Player : Entity
    {
        public static Player Me;
        
        [SerializeField] private float _movementSpeed;

        public Inventory Inventory = new Inventory(20);

        private void Awake()
        {
            Me = this;
        }

        private void Update()
        {
            Move();
            Interact();
        }

        private void Move()
        {
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
                
                if (hit.collider != null)
                {
                    MonoBehaviour[] components = hit.collider.GetComponents<MonoBehaviour>();

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
    }
}