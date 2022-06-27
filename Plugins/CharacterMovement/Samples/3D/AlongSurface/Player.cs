using System;
using CharacterMovement.Movement;
using UnityEngine;

namespace CharacterMovement.Samples._3D.AlongSurface
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Speed _speed;
        [SerializeField] private float _minAngle = 60f;
        [SerializeField] private LayerMask _ignoreMask;

        private IMovement _movement;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            var collider = GetComponent<CapsuleCollider>();

            _movement = new Movement.AlongSurface(
                _rb,
                _speed,
                new FilteredRay(
                    _ignoreMask,
                    QueryTriggerInteraction.Ignore),
                new MovementAngle(
                    _minAngle));
        }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            
            

            _movement.Move(new Vector3(x, 0, z));
        }

    }
}