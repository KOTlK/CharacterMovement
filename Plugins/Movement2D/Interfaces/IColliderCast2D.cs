using UnityEngine;

namespace CharacterMovement.Movement2D
{
    public interface IColliderCast2D
    {
        Cast2DResult Cast(Vector3 direction);
    }
}