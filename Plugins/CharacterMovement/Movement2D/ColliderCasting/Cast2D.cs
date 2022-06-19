using UnityEngine;
using CharacterMovement.Movement2D.Extensions;


namespace CharacterMovement.Movement2D
{
    public class Cast2D : IColliderCast2D
    {
        private readonly Collider2D _collider;
        private readonly IConstantCastDistance _castDistance;

        public Cast2D(Collider2D collider, IConstantCastDistance castDistance)
        {
            _collider = collider;
            _castDistance = castDistance;
        }
        
        public Cast2DResult Cast(Vector3 direction)
        {
            var result = new RaycastHit2D[8];

            if (_collider.Cast(direction, result, _castDistance.Value) == 0) return Cast2DResult.None;

            return new Cast2DResult(result.ExcludeNull());
        }

    }
}