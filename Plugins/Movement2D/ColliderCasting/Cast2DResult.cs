using System;
using System.Collections;
using UnityEngine;

namespace CharacterMovement.Movement2D
{
    public readonly struct Cast2DResult : IEnumerable
    {
        public static readonly Cast2DResult None = new Cast2DResult(Array.Empty<RaycastHit2D>());

        private readonly RaycastHit2D[] _contacts;
        
        public Cast2DResult(RaycastHit2D[] contacts)
        {
            _contacts = contacts;
        }
        
        public int Count => _contacts.Length;

        public static bool operator ==(Cast2DResult first, Cast2DResult second)
        {
            return first.Equals(second);
        }
        
        public static bool operator !=(Cast2DResult first, Cast2DResult second)
        {
            return !first.Equals(second);
        }

        public override bool Equals(object obj)
        {
            if (obj is Cast2DResult == false) return false;
            
            return obj.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return _contacts.GetHashCode();
        }
        

        public IEnumerator GetEnumerator()
        {
            return _contacts.GetEnumerator();
        }
    }
}