using UnityEngine;

namespace CharacterMovement.Movement2D
{
    public interface ISimpleCast2D
    {
        bool Cast(Vector3 direction);
    }
}