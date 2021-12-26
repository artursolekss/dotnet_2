
namespace CSharp.Activity.Events
{
    public enum ArrivalStatus
    {
        Arriving,
        Delayed,
        Cancelled
    }

    public class Program
    {
        static void Main(string[] args)
        {

            TrainStation trainStation = new TrainStation(); 

            trainStation.Arrival += StatusDeclare;
            trainStation.Arrival += ArrivalTime;
            trainStation.AnnounceArrival(12, ArrivalStatus.Arriving, new DateTime(2021, 12, 26));
        }

        private static void ArrivalTime(object sender, ArrivalEventArgs e)
        {
            Console.WriteLine("Expected arrival time of train No." + e.TrainNumber + " is " + e.ArrivalTime);
        }
        private static void StatusDeclare(object sender, ArrivalEventArgs e)
        {

            ArrivalStatus value = e.ArrivalStatus;
            switch (value)
            {
                case ArrivalStatus.Arriving:
                    Console.WriteLine("The train " + e.TrainNumber + " is arriving");
                    break;
                case ArrivalStatus.Delayed:
                    Console.WriteLine("The train " + e.TrainNumber + " is delayed");
                    break;
                case ArrivalStatus.Cancelled:
                    Console.WriteLine("The train " + e.TrainNumber + " is cancelled");
                    break;
            }
        }
    }

}
