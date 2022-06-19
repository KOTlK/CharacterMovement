using System;
using UnityEngine;

namespace CharacterMovement.Samples.VelocityChange
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;

        private IMovement _movement;
        
        private void Awake()
        {
            var rb = GetComponent<Rigidbody2D>();

            _movement = new Movement2D.VelocityChange(
                rb,
                new Speed(_speed));
        }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");
            
            _movement.Move(new Vector3(x, y));
        }
    }
}