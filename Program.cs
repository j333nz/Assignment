//Ho Zhen Yi S10267291 : Q1, Q4, Q7, Q8
//Pang Ai Jie Jennie S10268150 : Q2, Q3, Q5, Q6, Q9

using System;
using Assignment;

//Q1
Dictionary<string, string> airlinesDict= new Dictionary<string, string>();
Dictionary<string, BoardingGate> boardinggateDict = new Dictionary<string, BoardingGate>();
string airlineLines[] = File.ReadAllLines("airlines.csv");
foreach (string line in airlineLines)
{
    string[] data = line.Split(',');
    Airline a = new Airline(data[0], data[1]);
    airlinesDict.Add(a.Code, a);
}
string boardinggateLines[] = File.ReadAllLines("boardinggates.csv");
foreach (string line in boardinggateLines)
{
    string[] data = line.Split(",");
    BoardingGate b = new BoardingGate(data[0], data[1], data[2], data[3]);
    boardinggateDict.Add(b.GateName, b);
}

//Q2
Dictionary<string, Flight> flightsDict = new Dictionary<string, Flight>();
string flightLnes[] = File.ReadAllLines("flights.csv");

foreach (string line in flightLnes)
{
    string[] data = line.Split(',');
    Flight f = new Flight(data[0], data[1], data[2], Convert.ToDateTime(data[3]), data[4]);
    flightsDict.Add(data[0], f);
}

//Q3
void LoadFiles(Dictionary<string, Flight>(), Dictionary<string, string>())
{
    Console.WriteLine("=============================================" +
        "\r\nList of Flights for Changi Airport Terminal 5" +
        "\r\n=============================================");
    foreach (KeyValuePair<string, string> keyValuePair in airlinesDict)
    {
        foreach (KeyValuePair<string, Flight> kvp in flightsDict)
        {
            if (kvp.Key.Contains(keyValuePair.Value))
            {
                string airlineName = keyValuePair.Key;
                Console.WriteLine($"{kvp.Value.FlightNumber:-16}{airlineName:-23}{kvp.Value.Origin:-23}{kvp.Value.Destination:-23}{kvp.Value.ExpectedTime}");
            }
        }
    }
}

//Q4
void ListBoardingGates(Dictionary<string, BoardingGate>())
{
    Console.WriteLine("=============================================" +
        "\r\nList of Boarding Gates for Changi Airport Terminal 5" +
        "\r\n=============================================");
    foreach (KeyValuePair<string, BoardingGate> kvp in boardingDict)
    {
        Console.WriteLine($"{kvp.GetName} {kvp.SupportsDDJB} {kvp.SupportsCFFT} {kvp.SupportsLWTT}");
    }
}

//Q5

//Q6

//Q7

//Q8

//Q9

//main loop
while (true)
{
    Console.WriteLine("=============================================" +
        "\r\nWelcome to Changi Airport Terminal 5" +
        "\r\n=============================================" +
        "\r\n1. List All Flights" +
        "\r\n2. List Boarding Gates" +
        "\r\n3. Assign a Boarding Gate to a Flight" +
        "\r\n4. Create Flight" +
        "\r\n5. Display Airline Flights" +
        "\r\n6. Modify Flight Details" +
        "\r\n7. Display Flight Schedule" +
        "\r\n0. Exit");
    Console.WriteLine("Please select your option:");
    int option = Convert.ToInt32(Console.ReadLine());

    if (option == 1)
    {
        LoadFiles(flightsDict, airlinesDict);
    }
}