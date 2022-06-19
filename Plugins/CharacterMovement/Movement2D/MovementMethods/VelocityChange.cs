using UnityEngine;

namespace CharacterMovement.Movement2D
{
    public class VelocityChange : IMovement
    {
        private readonly Rigidbody2D _rb;
        private readonly ISpeed _speed;

        /// <summary>
        /// Moves body changing its velocity
        /// </summary>
        /// <param name="rb">Rigidbody component</param>
        /// <param name="speed">Movement speed</param>
        public VelocityChange(Rigidbody2D rb, ISpeed speed)
        {
            _rb = rb;
            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero) return;
            
            var velocity = _rb.velocity;

            if (direction.y != 0) velocity.y = direction.y * _speed.Current;
            if (direction.x != 0) velocity.x = direction.x * _speed.Current;

            _rb.velocity = velocity;
        }

    }
}