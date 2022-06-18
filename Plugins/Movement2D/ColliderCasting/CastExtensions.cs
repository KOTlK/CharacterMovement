using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CharacterMovement.Movement2D.Extensions
{
    public static class CastExtensions
    {
        public static RaycastHit2D[] ExcludeNull(this IEnumerable<RaycastHit2D> hits)
        {
            return hits.TakeWhile(hit => hit.collider != null).ToArray();
        }
    }
}