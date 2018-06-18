namespace WillBeEnterprise.Models
{
    public class Mastery
    {
        public int Reading { get; private set; }
        public int Writing { get; private set; }
        public int Listening { get; private set; }
        public int Speaking { get; private set; }

        public Mastery(int reading, int writing, int listening, int speaking)
        {
            Reading = reading;
            Writing = writing;
            Listening = listening;
            Speaking = speaking;
        }
    }
}
