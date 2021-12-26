namespace CSharp.Activity.Events
{
    public class ArrivalEventArgs
    {

        public int TrainNumber { get; private set; }
        public ArrivalStatus ArrivalStatus { get; private set; }
        public DateTime ArrivalTime { get; private set; }

        public ArrivalEventArgs(int num, ArrivalStatus status, DateTime time)
        {
            this.TrainNumber = num;
            this.ArrivalStatus = status;
            this.ArrivalTime = time;
        }

    }
}
