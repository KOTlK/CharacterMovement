using UnityEngine;

namespace CharacterMovement.Movement2D
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class Normal : MonoBehaviour, INormal
    {
        private Collider2D _collider;
        public Vector3 Average => Recalculate();

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private Vector3 Recalculate()
        {
            var contacts = new ContactPoint2D[8];
            var average = Vector3.zero;
            var count = 0;

            if (_collider.GetContacts(contacts) == 0) return Vector3.zero;

            foreach (var contact in contacts)
            {
                if (contact.collider == null) continue;

                average += (Vector3)contact.normal;
                count++;
            }

            average /= count;
            return average;
        }
    }
}