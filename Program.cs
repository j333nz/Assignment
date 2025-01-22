//Ho Zhen Yi S10267291 : Q1, Q4, Q7, Q8
//Pang Ai Jie Jennie S10268150 : Q2, Q3, Q5, Q6, Q9

using System;
using Assignment;

//Q1
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

//Q2
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
}

//Q3
void LoadFiles(Dictionary<string, Flight> flightsDict, Dictionary<string, string> airlinesDict )
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
void ListBoardingGates(Dictionary<string, BoardingGate> boardinggateDict)
{
    Console.WriteLine("=============================================" +
        "\r\nList of Boarding Gates for Changi Airport Terminal 5" +
        "\r\n=============================================");
    Console.WriteLine("Gate Name", "DDJB", "CFFT", "LWTT");
    foreach (BoardingGate boardingGate in boardinggateDict.Values)
    {
        Console.WriteLine($"{boardingGate.GateName} {boardingGate.SupportsDDJB} {boardingGate.SupportsCFFT} {boardingGate.}");
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