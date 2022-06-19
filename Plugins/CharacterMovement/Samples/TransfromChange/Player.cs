using System;
using CharacterMovement.Movement2D;
using UnityEngine;

namespace CharacterMovement.Samples.Transform
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;

        private Collider2D _collider;
        private IMovement _movement;


        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            
            var rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
        }

        private void Start()
        {
            _movement = new TransformChange(
                transform,
                new Speed(_speed),
                new Cast2D(
                    _collider,
                    new ConstantCastDistance()));
        }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (x == 0 && y == 0) return;
            
            _movement.Move(new Vector3(x, y));
        }

    }
}