using UnityEngine;
using CharacterMovement.Movement.Extensions;

namespace CharacterMovement.Movement
{
    public interface IRaycast
    {
        Contacts Cast(Vector3 position, Vector3 direction);

        public sealed class Default : IRaycast
        {
            private readonly float _maxDistance;
            private readonly int _maxHits;

            public Default(float maxDistance, int maxHits)
            {
                _maxDistance = maxDistance;
                _maxHits = maxHits;
            }

            public Contacts Cast(Vector3 origin, Vector3 direction)
            {
                var hits = new RaycastHit[_maxHits];
                if (Physics.RaycastNonAlloc(origin, direction, hits, _maxDistance) == 0) return Contacts.None;

                return hits.ExtractContacts();
            }
        }
    }
}