using UnityEngine;
using CharacterMovement.Movement2D.Extensions;

namespace CharacterMovement.Movement2D
{
    public class BoxCast2D : IColliderCast2D
    {
        private readonly IConstantCastDistance _castDistance;
        private readonly LayerMask _ignoreMask;
        private readonly Transform _origin;
        private readonly Vector2 _size;

        public BoxCast2D(Transform transform, Vector2 size, IConstantCastDistance castDistance, LayerMask ignoreLayers)
        {
            _origin = transform;
            _size = size;
            _castDistance = castDistance;
            _ignoreMask = ignoreLayers;
        }
        
        public Cast2DResult Cast(Vector3 direction)
        {
            var result = new RaycastHit2D[8];

            if (Physics2D.BoxCastNonAlloc(_origin.position,
                _size,
                0f, 
                direction, 
                result, 
                _castDistance.Value,
                ~_ignoreMask) == 0) return Cast2DResult.None;

            return new Cast2DResult(result.ExcludeNull());
        }

    }
}