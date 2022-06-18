using UnityEngine;

namespace CharacterMovement.Movement2D
{
    public class TransformChange : IMovement
    {
        private readonly Transform _origin;
        private readonly ISpeed _speed;
        private readonly IColliderCast2D _castMethod;

        /// <summary>
        /// Moves body changing its transform coordinates
        /// </summary>
        /// <param name="origin">Transform origin</param>
        /// <param name="speed">Movement speed</param>
        /// <param name="castMethod">Casting method</param>
        public TransformChange(Transform origin, ISpeed speed, IColliderCast2D castMethod)
        {
            _origin = origin;
            _speed = speed;
            _castMethod = castMethod;
        }


        public void Move(Vector3 direction)
        {
            if (_castMethod.Cast(direction) != Cast2DResult.None) return;

            _origin.position += direction * _speed.Current * Time.deltaTime;
        }
    }
}