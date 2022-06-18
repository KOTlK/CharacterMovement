using UnityEngine;
using CharacterMovement.Movement2D.Extensions;

namespace CharacterMovement.Movement2D
{
    public class BoxCast2D : IColliderCast2D
    {
        private readonly BoxCollider2D _collider;
        private readonly IConstantCastDistance _castDistance;
        private readonly LayerMask _ignoreMask;

        public BoxCast2D(BoxCollider2D collider, IConstantCastDistance castDistance, LayerMask ignoreLayers)
        {
            _collider = collider;
            _castDistance = castDistance;
            _ignoreMask = ignoreLayers;
        }
        
        public Cast2DResult Cast(Vector3 direction)
        {
            var result = new RaycastHit2D[8];

            if (Physics2D.BoxCastNonAlloc(_collider.transform.position,
                _collider.size,
                0f, 
                direction, 
                result, 
                _castDistance.Value,
                ~_ignoreMask) == 0) return Cast2DResult.None;

            return new Cast2DResult(result.ExcludeNull());
        }

    }
}