using System;
using CharacterMovement.Movement2D;
using UnityEngine;

namespace CharacterMovement.Samples.AlongSurface2D
{
    [RequireComponent(typeof(Normal))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Vector3 _normal;
        
        private IMovement _movement;

        private void Awake()
        {
            var normal = GetComponent<Normal>();
            var rb = GetComponent<Rigidbody2D>();

            _movement = new Movement2D.AlongSurface2D(
                rb,
                new Speed(_speed),
                normal,
                new ValidNormal(
                    new NormalRestrictions(_normal)));
        }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal");

            _movement.Move(new Vector3(x,0));
        }
    }
}