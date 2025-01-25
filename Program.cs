﻿//Ho Zhen Yi S10267291 : Q1, Q4, Q7, Q8
//Pang Ai Jie Jennie S10268150 : Q2, Q3, Q5, Q6, Q9

using System;
using Assignment;

//Q1 completed
Dictionary<string, string> airlinesDict= new Dictionary<string, string>();
Dictionary<string, BoardingGate> boardinggateDict = new Dictionary<string, BoardingGate>();
string[] airlineLines = File.ReadAllLines("airlines.csv");
for (int i = 1; i< airlineLines.Length; i++ )
{
    string[] data = airlineLines[i].Split(',');
    string airlineName = data[0];
    string airlineCode = data[1];
    Airline a = new Airline(airlineName, airlineCode);
    airlinesDict.Add(a.Code, a.Name);
}
string[] boardinggateLines = File.ReadAllLines("boardinggates.csv");
for (int i = 1; i < boardinggateLines.Length; i++)
{
    string[] data = boardinggateLines[i].Split(",");
    string boardinggateName = data[0];
    bool ddjb = Convert.ToBoolean(data[1]);
    bool cfft = Convert.ToBoolean(data[2]);
    bool lwtt = Convert.ToBoolean(data[3]);
    BoardingGate b = new BoardingGate(boardinggateName, cfft, ddjb, lwtt);
    boardinggateDict.Add(b.GateName, b);
}

//Q2 completed
Dictionary<string, Flight> flightsDict = new Dictionary<string, Flight>();
string[] flightLines = File.ReadAllLines("flights.csv");

for (int i = 1; i < flightLines.Length; i++)
{
    string[] data = flightLines[i].Split(',');
    string flightNumber = data[0];
    string origin = data[1];
    string destination = data[2];
    DateTime expectedDate = Convert.ToDateTime(data[3]);
    string status = data[4];
    Flight f = new Flight(flightNumber, origin, destination, expectedDate, status);
    flightsDict.Add(f.FlightNumber, f);
}

//Q3 completed
void ListAllFlights(Dictionary<string, string> airlinesDict, Dictionary<string, Flight> flightsDict)
{
    foreach (KeyValuePair<string, Flight> kvp in flightsDict)
    {
        foreach (KeyValuePair<string, string> keyvaluepair in airlineDict)
        {
            if (kvp.Key.Contains(keyvaluepair.Value))
            {
                string airlineName = keyvaluepair.Value;
                Console.WriteLine($"{kvp.Value.FlightNumber, -16}{airlineName, -23}{kvp.Value.Origin, -23}{kvp.Value.Destination, -23}{kvp.Value.ExpectedTime}");
            }
        }
    }

//Q4 completed
void ListBoardingGates(Dictionary<string, BoardingGate> boardinggateDict)
{
    foreach (BoardingGate boardingGate in boardinggateDict.Values)
    {
        Console.WriteLine($"{boardingGate.GateName} {boardingGate.SupportsDDJB} {boardingGate.SupportsCFFT} {boardingGate.SupportsLWTT}");
    }
}

//Q5
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
            Console.Write("Would you like to update the status of the flight? (Y/N)")
            string response = Console.ReadLine();
            if (response == "Y")
            {
                Console.WriteLine("1. Delayed" + "\n2. Boarding" + "\n3. On Time")
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
    Console.WlriteLine(" ");
    Console.WriteLine("Please select your option:");
    int option = Convert.ToInt32(Console.ReadLine());

        if (option == 1)
        {
            Console.WriteLine("=============================================" +
                "\nList of Flights for Changi Airport Terminal 5" +
                "\n=============================================");
            Console.WriteLine($"{"Flight Number",-16} {"Airline Name",-23} {"Origin",-23} {"Destination",-23} {"Expected Depareture/Arrival"}");
            ListAllFlights(airlinesDict, flightsDict);
        }
        else if (option == 2)
        {
            Console.WriteLine("=============================================" +
                "\nList of Boarding Gates for Changi Airport Terminal 5" +
                "\n=============================================");
            Console.WriteLine($"{"Gate Name",-16}{"DDJB",-23}{"CFFT",-23}{"LWTT"}");
        }
        else if (option == 3)
        {

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