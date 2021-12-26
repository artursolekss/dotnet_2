
namespace CSharp.Activity.Events
{
    public class TrainStation
    {
        public event EventHandler<ArrivalEventArgs> Arrival;

        protected void OnArrival(ArrivalEventArgs e)
        {
            if (this.Arrival != null)
                this.Arrival(this, e);
            //   Arrival?.Invoke(this, e); SIMILAR
        }

        public void AnnounceArrival(int train, ArrivalStatus arrivalStatus, DateTime arrivalTime)
        {
            this.OnArrival(new ArrivalEventArgs(train, arrivalStatus, arrivalTime));

        }


    }


}
