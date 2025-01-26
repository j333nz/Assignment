//Ho Zhen Yi S10267291 : Q1, Q4, Q7, Q8
//Pang Ai Jie Jennie S10268150 : Q2, Q3, Q5, Q6, Q9

using System;
using Assignment;

//Q1 completed - Ho Zhen Yi S10267291
Dictionary<string, string> airlinesDict= new Dictionary<string, string>();
Dictionary<string, BoardingGate> boardinggateDict = new Dictionary<string, BoardingGate>();
string[] airlineLines = File.ReadAllLines("airlines.csv");
for (int i = 1; i< airlineLines.Length; i++ )
{
    string[] data = airlineLines[i].Trim().Split(',');
    string airlineName = data[0];
    string airlineCode = data[1];
    Airline a = new Airline(airlineName, airlineCode);
    airlinesDict.Add(a.Name, a.Code);
}
string[] boardinggateLines = File.ReadAllLines("boardinggates.csv");
for (int i = 1; i < boardinggateLines.Length; i++)
{
    string[] data = boardinggateLines[i].Trim().Split(",");
    string boardinggateName = data[0];
    bool ddjb = Convert.ToBoolean(data[1]);
    bool cfft = Convert.ToBoolean(data[2]);
    bool lwtt = Convert.ToBoolean(data[3]);
    BoardingGate b = new BoardingGate(boardinggateName, cfft, ddjb, lwtt);
    boardinggateDict.Add(b.GateName, b);
}

//Q2 completed - Pang Ai Jie Jennie S10268150
Dictionary<string, Flight> flightsDict = new Dictionary<string, Flight>();
string[] flightLines = File.ReadAllLines("flights.csv");

for (int i = 1; i < flightLines.Length; i++)
{
    string[] data = flightLines[i].Trim().Split(',');
    string flightNumber = data[0];
    string origin = data[1];
    string destination = data[2];
    DateTime expectedDate = Convert.ToDateTime(data[3]);
    string status = data[4];
    Flight f;
    if (status == "DDJB")
    {
        f = new DDJBFlight(flightNumber, origin, destination, expectedDate, status);
    }
    else if (status == "CFFT")
    {
        f = new CFFTFlight(flightNumber, origin, destination, expectedDate, status);
    }
    else if (status == "LWTT")
    {
        f = new LWTTFlight(flightNumber, origin, destination, expectedDate, status);
    }
    else
    {
        f = new NORMFlight(flightNumber, origin, destination, expectedDate, status);
    }
    flightsDict.Add(f.FlightNumber, f);
}

//Q3 completed - Pang Ai Jie Jennie S10268150
void ListAllFlights(Dictionary<string, string> airlinesDict, Dictionary<string, Flight> flightsDict)
{
    foreach (KeyValuePair<string, Flight> kvp in flightsDict)
    {
        foreach (KeyValuePair<string, string> keyvaluepair in airlinesDict)
        {
            if (kvp.Value.FlightNumber.Contains(keyvaluepair.Value))
            {
                string airlineName = keyvaluepair.Key;
                Console.WriteLine($"{kvp.Value.FlightNumber,-17}{airlineName,-24}{kvp.Value.Origin,-24}{kvp.Value.Destination,-24}{kvp.Value.ExpectedTime}");
            }
        }
    }
}

//Q4 completed - Ho Zhen Yi S10267291
void ListBoardingGates(Dictionary<string, BoardingGate> boardinggateDict)
{
    foreach (BoardingGate boardingGate in boardinggateDict.Values)
    {
        Console.WriteLine($"{boardingGate.GateName,-16} {boardingGate.SupportsDDJB,-23} {boardingGate.SupportsCFFT,-23} {boardingGate.SupportsLWTT}");
    }
}

//Q5 halfway - Pang Ai Jie Jennie S10268150
void AssignBoardingGateToFlight(Dictionary<string, Flight> flightsDict, Dictionary<string, BoardingGate> boardinggateDict)
{
    Console.Write("Enter Flight Number:");
    string flightNumber = Console.ReadLine();
    Console.Write("Enter Boarding Gate Name:");
    string boardingGateName = Console.ReadLine();
    if (flightsDict.ContainsKey(flightNumber) && boardinggateDict.ContainsKey(boardingGateName))
    {
        Flight f = flightsDict[flightNumber];
        BoardingGate b = boardinggateDict[boardingGateName];
        b.Flight = f;
        Console.WriteLine($"Flight Number: {f.FlightNumber}"
            + $"\nOrigin: {f.Origin}"
            + $"\nDestination: {f.Destination}"
            + $"\nExpected Time: {f.ExpectedTime}"
            + $"\nSpecial Request Code: {f.Status}"
            + $"\nBoarding Gate Name: {b.GateName}"
            + $"\nSupports DDJB: {b.SupportsDDJB}"
            + $"\nSupports CFFT: {b.SupportsCFFT}"
            + $"\nSupports LWTT: {b.SupportsLWTT}");
        Console.Write("Would you like to update the status of the flight? (Y/N)");
        string response = Console.ReadLine();
        if (response == "Y")
        {
            Console.WriteLine("1. Delayed" + "\n2. Boarding" + "\n3. On Time");
            Console.Write("Please select the new status of the flight:");
            string newStatus = Console.ReadLine();
        }
    }
}

//Q6

//Q7

//Q8

//Q9

//main loop
while (true)
{
    Console.WriteLine("=============================================" +
        "\nWelcome to Changi Airport Terminal 5" +
        "\n=============================================" +
        "\n1. List All Flights" +
        "\n2. List Boarding Gates" +
        "\n3. Assign a Boarding Gate to a Flight" +
        "\n4. Create Flight" +
        "\n5. Display Airline Flights" +
        "\n6. Modify Flight Details" +
        "\n7. Display Flight Schedule" +
        "\n0. Exit");
    Console.WriteLine(" ");
    Console.WriteLine("Please select your option:");
    int option = Convert.ToInt32(Console.ReadLine());

    if (option == 1)
    {
        Console.WriteLine("=============================================" +
            "\nList of Flights for Changi Airport Terminal 5" +
            "\n=============================================");
        Console.WriteLine($"{"Flight Number", -16} {"Airline Name", -23} {"Origin", -23} {"Destination",-23} {"Expected Depareture/Arrival"}");
        ListAllFlights(airlinesDict, flightsDict);
    }
    else if (option == 2)
    {
        Console.WriteLine("=============================================" +
            "\nList of Boarding Gates for Changi Airport Terminal 5" +
            "\n=============================================");
        Console.WriteLine($"{"Gate Name",-17}{"DDJB",-24}{"CFFT",-24}{"LWTT"}");
        ListBoardingGates(boardinggateDict);
    }
    else if (option == 3)
    {
        AssignBoardingGateToFlight(flightsDict, boardinggateDict);
    }
    else if (option == 4)
    {

    }
    else if (option == 5)
    {

    }
    else if (option == 6)
    {

    }
    else if (option == 7)
    {

    }
    else if (option == 0)
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid option. Please try again.");
    }
}