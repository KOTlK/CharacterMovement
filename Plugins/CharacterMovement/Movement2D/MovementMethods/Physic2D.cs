using UnityEngine;

namespace CharacterMovement.Movement2D
{
    public class Physic2D : IMovement
    {
        private readonly IColliderCast2D _cast;
        private readonly Rigidbody2D _rigidbody;
        private readonly ISpeed _speed;
        private readonly NormalRestrictions _normalRestrictions;

        /// <summary>
        /// Checks whether the collider is surface and moves with specified movement speed.
        /// </summary>
        /// <param name="cast">Cast method</param>
        /// <param name="speed">Movement speed</param>
        /// <param name="normalRestrictions">Maximum normal values</param>
        /// <param name="rigidbody">Rigidbody component of body</param>
        public Physic2D(IColliderCast2D cast, Rigidbody2D rigidbody, ISpeed speed, NormalRestrictions normalRestrictions)
        {
            _cast = cast;
            _rigidbody = rigidbody;
            _speed = speed;
            _normalRestrictions = normalRestrictions;
        }

        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero) return;
            
            var castResult = _cast.Cast(direction);

            if (castResult.Equals(Cast2DResult.None))
            {
                SetVelocity(direction);
                return;
            }

            foreach (RaycastHit2D collision in castResult)
            {
                if (collision.normal.y < _normalRestrictions.Y)
                {
                    SetVelocity(Vector3.zero);
                    return;
                }

                if (collision.normal.x > _normalRestrictions.X || collision.normal.x < -_normalRestrictions.X)
                {
                    SetVelocity(Vector3.zero);
                    return;
                }
            }

            SetVelocity(direction);
        }

        private void SetVelocity(Vector3 value)
        {
            if (value == Vector3.zero)
            {
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
                return;
            }
            
            var velocity = _rigidbody.velocity;

            if (value.y != 0) velocity.y = value.y;
            if (value.x != 0) velocity.x = value.x * _speed.Current;

            _rigidbody.velocity = velocity;
        }

    }
}