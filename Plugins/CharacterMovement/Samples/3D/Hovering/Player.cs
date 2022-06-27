using System;
using CharacterMovement.Movement;
using UnityEngine;

namespace CharacterMovement.Samples._3D.Hovering
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _flightHeight = 1f;
        [Range(0, 1)][SerializeField] private float _speedDecay = 0.5f;
        [Range(0, 1)][SerializeField] private float _damping = 0.5f;

        private IMovement _movement;

        private void Awake()
        {
            var rb = GetComponent<Rigidbody>();

            _movement = new Hover(
                rb,
                new Speed(
                    _speed),
                _flightHeight,
                _damping,
                _speedDecay);
        }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            _movement.Move(new Vector3(x, 0, z));
        }
    }
}