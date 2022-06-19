using UnityEngine;
using CharacterMovement.Movement2D.Extensions;


namespace CharacterMovement.Movement2D
{
    public class FilteredCast2D : IColliderCast2D
    {
        private readonly Collider2D _collider;
        private readonly ContactFilter2D _filter;
        private readonly IConstantCastDistance _castDistance;

        public FilteredCast2D(Collider2D collider, ContactFilter2D filter, IConstantCastDistance castDistance)
        {
            _collider = collider;
            _filter = filter;
            _castDistance = castDistance;
        }
        
        public Cast2DResult Cast(Vector3 direction)
        {
            var result = new RaycastHit2D[8];
            
            if (_collider.Cast(direction, _filter, result, _castDistance.Value) == 0) return Cast2DResult.None;

            return new Cast2DResult(result.ExcludeNull());
        }
        
    }
}