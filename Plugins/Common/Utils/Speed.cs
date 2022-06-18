namespace CharacterMovement
{
    //Horrible mutable shit. Should not exist, but.
    public class Speed : ISpeed
    {
        public Speed(float start)
        {
            Current = start;
        }
        
        public float Current { get; private set; }

        public void Change(float newSpeed)
        {
            Current = newSpeed;
        }
    }
}