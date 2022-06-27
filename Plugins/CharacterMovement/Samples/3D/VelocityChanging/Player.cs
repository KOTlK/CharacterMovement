using UnityEngine;
using CharacterMovement.Movement;

namespace CharacterMovement.Samples._3D.VelocityChanging
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private float _speed = 10f;

        private Movement.VelocityChange _movement;
        private OverlapCapsuleFiltered _cast;

        private void Awake()
        {
            var rb = GetComponent<Rigidbody>();
            var collider = GetComponent<CapsuleCollider>();
            
            _movement = new Movement.VelocityChange(
                _cast = new OverlapCapsuleFiltered(
                    new Capsule(
                        collider),
                    _mask,
                    QueryTriggerInteraction.Ignore),
                new Speed(_speed),
                rb);

        }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            
            _movement.Move(new Vector3(x, 0, z));
        }

        private void OnDrawGizmos()
        {
            _cast.DrawGizmos();
        }
    }
}