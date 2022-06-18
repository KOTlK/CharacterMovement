using UnityEngine;

namespace CharacterMovement.Movement2D
{
    public class AlongSurface2D : IMovement
    {
        private readonly Rigidbody2D _rb;
        private readonly ISpeed _speed;
        private readonly ValidNormal _validator;
        private readonly INormal _normal;

        /// <summary>
        /// Moves rigidbody along collided surface
        /// </summary>
        /// <param name="rb">Rigidbody component</param>
        /// <param name="speed">Movement speed</param>
        /// <param name="normal">Average surface normal</param>
        /// <param name="validator">Normal validation</param>
        public AlongSurface2D(Rigidbody2D rb, ISpeed speed, INormal normal, ValidNormal validator)
        {
            _rb = rb;
            _speed = speed;
            _normal = normal;
            _validator = validator;
        }

        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero) return;
            if (_normal.Average == Vector3.zero) return;

            if (_validator.IsValid(_normal.Average) == false)
            {
                return;
            }
            
            
            var offset = TargetDirection(direction, _normal.Average) * _speed.Current * Time.deltaTime;
            _rb.MovePosition(_rb.position + (Vector2)offset);
        }

        private Vector3 TargetDirection(Vector3 direction, Vector3 normal)
        {
            return direction - Vector3.Dot(direction, normal) * normal;
        }
    }
}