using System.Linq;
using UnityEngine;

namespace CharacterMovement.Movement.Extensions
{
    public static class Extensions
    {
        public static Contacts ExtractContacts(this RaycastHit[] hits)
        {
            return new Contacts(hits.TakeWhile(hit => hit.collider != null && hit.point != Vector3.zero).Select(hit => hit.normal).ToArray());
        }
        
        public static OverlapContacts ExtractContacts(this Collider[] colliders)
        {
            return new OverlapContacts(colliders.TakeWhile(collider => collider != null).ToArray());
        }

        public static Vector3 Average(this Contacts contacts)
        {
            var count = 0;
            var average = Vector3.zero;

            foreach (Vector3 contact in contacts)
            {
                count++;
                average += contact;
            }
            
            return average / count;
        }

        
    }
}