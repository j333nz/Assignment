//Ho Zhen Yi S10267291 : Q1, Q4, Q7, Q8
//Pang Ai Jie Jennie S10268150 : Q2, Q3, Q5, Q6, Q9

using System;
using Assignment;

//Q1
Dictionary<string, string> airlinesDict= new Dictionary<string, string>();
string airlineLines[] = File.ReadAllLines("airlines.csv");
foreach (string line in airlineLines)
{
    string[] data = line.Split(',');
    Airline a = new Airline(data[0], data[1]);
    airlinesDict.Add(data[0], data[1]);
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

//Q5

//Q6

//Q7

//Q8

//Q9

//main loop