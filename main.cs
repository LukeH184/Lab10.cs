using System;

class Program {
  public static void Main (string[] args) {
    int time1, time2, diff;
    
    try{
    Console.WriteLine("Enter time 1 in 24hr format as follows (HH:MM:SS)");
    string t1 = Console.ReadLine();
    time1 = time_to_seconds(t1);
    
      Console.WriteLine("Enter time 2 in 24hr format as follows (HH:MM:SS)");
    string t2 = Console.ReadLine();
    time2 = time_to_seconds(t2);
    if (time1 > time2) diff = time1 - time2;
            else diff = time2 - time1;
      
      Console.WriteLine("Difference in seconds: " + diff);
    }
   
    catch (InvalidTimeException e){
      Console.WriteLine("Exception thrown: " + e.Message);
    }
  
  int time_to_seconds(string s){
    string [] time_ar = s.Split(":", 3);
    if(time_ar.Length != 3){
      throw new InvalidTimeException("Enter a Valid Time");
    }
    
    int hours = Convert.ToInt32(time_ar[0]);
    int minutes = Convert.ToInt32(time_ar[1]);
    int seconds = Convert.ToInt32(time_ar[2]);

    if (hours < 0) throw new InvalidTimeException ("Hours must be positive");
    if (hours > 23) throw new InvalidTimeException ("Hours must be less than 24");

    if (minutes < 0) throw new InvalidTimeException ("Minutes must be Positive");
    if (minutes > 59 ) throw new InvalidTimeException ("Minutes must be below 60");

    if (seconds < 0) throw new InvalidTimeException ("Seconds must be Positive");
    if (seconds > 59 ) throw new InvalidTimeException ("Seconds must be below 60");
    
    return hours * 60 * 60 + minutes * 60 + seconds;
    }
  }
  public class InvalidTimeException : Exception {
    public InvalidTimeException (){}
    public InvalidTimeException (string message){
      Console.WriteLine(message);
    }
  }
}