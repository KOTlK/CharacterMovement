using CharacterMovement.Movement2D;
using UnityEngine;

namespace CharacterMovement.Samples.Physics2D
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Vector3 _normalRestrictions;

        private IMovement _movement;
        private Rigidbody2D _rb;

        private void Awake()
        {
            var collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();

            _movement = new Physic2D(
                new Cast2D(
                    collider,
                    new ConstantCastDistance()),
                _rb,
                new Speed(_speed),
                new NormalRestrictions(_normalRestrictions));
        }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal");
            
            _movement.Move(new Vector3(x, 0));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movement.Move(new Vector3(0, 10, 0));
            }
        }
    }
}