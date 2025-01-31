//==========================================================
// Student Number  : S10268150
// Student Name  : Pang Ai Jie Jennie - Q2, Q3, Q5, Q6, Q9
// Partner Name  : Ho Zhen Yi - Q1, Q4, Q7, Q8
//==========================================================

//Dictionary list: (so we dont keep scrolling through the code LOL)
//Dictionary<string, string> FlightNumToGate key: FlightNumber, value: BoardingGateName
//Dictionary<string, string> airlinesDict key: AirlineName, value: AirlineCode
//Dictionary<string, BoardingGate> boardinggateDict key: BoardingGateName, value: BoardingGate
//Dictionary<string, Flight> flightsDict key: FlightNumber, value: Flight
//Dictionary<string, string> FlightAndSpecialCodeDict key: FlightNumber, value: SpecialCode

using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
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
Dictionary<string, string> FlightAndSpecialCodeDict = new Dictionary<string, string>();
string[] flightLines = File.ReadAllLines("flights.csv");
for (int i = 1; i < flightLines.Length; i++)
{
    string[] data = flightLines[i].Trim().Split(',');
    string flightNumber = data[0];
    string origin = data[1];
    string destination = data[2];
    DateTime expectedDate = Convert.ToDateTime(data[3]);
    string specialCode = data[4];
    Flight f;
    if (specialCode == "DDJB")
    {
        f = new DDJBFlight(flightNumber, origin, destination, expectedDate);
    }
    else if (specialCode == "CFFT")
    {
        f = new CFFTFlight(flightNumber, origin, destination, expectedDate);
    }
    else if (specialCode == "LWTT")
    {
        f = new LWTTFlight(flightNumber, origin, destination, expectedDate);
    }
    else
    {
        f = new NORMFlight(flightNumber, origin, destination, expectedDate);
    }
    flightsDict.Add(f.FlightNumber, f);
    if (specialCode == "DDJB" || specialCode == "CFFT" || specialCode == "LWTT")
    {
        FlightAndSpecialCodeDict[f.FlightNumber] = specialCode;
    }
    else
    {
        FlightAndSpecialCodeDict[f.FlightNumber] = "None";
    }
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

//Q5 completed - Pang Ai Jie Jennie S10268150
Dictionary<string, string> FlightNumToGate = new Dictionary<string, string>();
//create dictionary to store flight number and boarding gate name
foreach (KeyValuePair<string, Flight> Kvp in flightsDict)
{
    FlightNumToGate.Add(Kvp.Value.FlightNumber, "Unassigned");
}
void AssignBoardingGateToFlight(Dictionary<string, Flight> flightsDict, Dictionary<string, BoardingGate> boardinggateDict, Dictionary<string, string> FlightAndSpecialCodeDict)
{
    while (true)
    {
        Console.WriteLine("Enter Flight Number:");
        string flightNum = Console.ReadLine().ToUpper().Replace(" ", "");
        Console.WriteLine("Enter Boarding Gate Name:");
        string boardingGateName = Console.ReadLine().ToUpper();
        bool flightExists = false;
        BoardingGate b = boardinggateDict[boardingGateName];
        foreach (KeyValuePair<string, Flight> kvp in flightsDict)
        {
            if (kvp.Key.Replace(" ", "") == flightNum)
            {
                flightNum = kvp.Key;
                flightExists = true;
                break;
            }
        }
        if (flightExists && boardinggateDict.ContainsKey(boardingGateName))
        {
            //assign gate to flight
            foreach (KeyValuePair<string, string> KVp in FlightNumToGate)
            {
                if (KVp.Key == flightNum)
                {
                    if (boardinggateDict[boardingGateName].SupportsDDJB == true && FlightAndSpecialCodeDict[flightNum] == "DDJB")
                    {
                        FlightNumToGate[KVp.Key] = boardingGateName;
                        boardinggateDict[b.GateName].Flight = flightsDict[KVp.Key];
                    }
                    else if (boardinggateDict[boardingGateName].SupportsCFFT == true && FlightAndSpecialCodeDict[flightNum] == "CFFT")
                    {
                        FlightNumToGate[KVp.Key] = boardingGateName;
                        boardinggateDict[b.GateName].Flight = flightsDict[KVp.Key];
                    }
                    else if (boardinggateDict[boardingGateName].SupportsLWTT == true && FlightAndSpecialCodeDict[flightNum] == "LWTT")
                    {
                        FlightNumToGate[KVp.Key] = boardingGateName;
                        boardinggateDict[b.GateName].Flight = flightsDict[KVp.Key];
                    }
                    else if (FlightAndSpecialCodeDict[flightNum] == "None")
                    {
                        FlightNumToGate[KVp.Key] = boardingGateName;
                        boardinggateDict[b.GateName].Flight = flightsDict[KVp.Key];
                    }
                    else
                    {
                        Console.WriteLine("Boarding Gate does not support the flight's special request code. Please try again.");
                        break;
                    }
                }
            }

            //display basic info of flight
            Flight f = flightsDict[flightNum];
            b.Flight = f;
            foreach (KeyValuePair<string, string> kvp in FlightAndSpecialCodeDict)
            {
                if (kvp.Key == f.FlightNumber)
                {
                    Console.WriteLine($"Flight Number: {f.FlightNumber}"
                        + $"\nOrigin: {f.Origin}"
                        + $"\nDestination: {f.Destination}"
                        + $"\nExpected Time: {f.ExpectedTime}"
                        + $"\nSpecial Request Code: {kvp.Value}"
                        + $"\nBoarding Gate Name: {b.GateName}"
                        + $"\nSupports DDJB: {b.SupportsDDJB}"
                        + $"\nSupports CFFT: {b.SupportsCFFT}"
                        + $"\nSupports LWTT: {b.SupportsLWTT}");
                    break;
                }
            }

            //update status of flight
            Console.WriteLine("Would you like to update the status of the flight? (Y/N)");
            string response = Console.ReadLine().ToUpper();
            if (response == "Y")
            {
                Console.WriteLine("1. Delayed" + "\n2. Boarding" + "\n3. On Time");
                Console.WriteLine("Please select the new status of the flight:");
                string newStatusOption = Console.ReadLine();
                if (newStatusOption == "1")
                {
                    f.Status = "Delayed";
                }
                else if (newStatusOption == "2")
                {
                    f.Status = "Boarding";
                }
                else if (newStatusOption == "3")
                {
                    f.Status = "On Time";
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
                }
            }
            else if (response == "N")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
                continue;
            }
            Console.WriteLine($"Flight {f.FlightNumber} has been assigned to Boarding Gate {b.GateName}!");
            break;
        }
        else
        {
            Console.WriteLine("Invalid Flight Number or Boarding Gate Name. Please try again.");
            continue;
        }
    }
}

//Q6 - completed Pang Ai Jie Jennie S10268150
void CreateFlight(Dictionary<string, Flight> flightsDict)
{
    while (true)
    {
        Console.Write("Enter Flight Number: ");
        string flightNumber = Console.ReadLine();
        Console.Write("Enter Origin: ");
        string origin = Console.ReadLine();
        Console.Write("Enter Destination: ");
        string destination = Console.ReadLine();
        Console.Write("Enter Expected Departure/Arrival Time (dd/mm/yyyy hh:mm): ");
        DateTime expectedTime = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Enter Special Request Code (CFFT/DDJB/LWTT/None): ");
        string specialCode = Console.ReadLine();

        //create flight object & add to dictionary
        Flight fl;
        if (specialCode == "CFFT")
        {
            fl = new CFFTFlight(flightNumber, origin, destination, expectedTime);
        }
        else if (specialCode == "DDJB")
        {
            fl = new DDJBFlight(flightNumber, origin, destination, expectedTime);
        }
        else if (specialCode == "LWTT")
        {
            fl = new LWTTFlight(flightNumber, origin, destination, expectedTime);
        }
        else
        {
            fl = new NORMFlight(flightNumber, origin, destination, expectedTime);
        }
        flightsDict.Add(fl.FlightNumber, fl);

        //append new flight info to flights.csv
        if (specialCode == "None")
        {
            string[] lines = { $"{flightNumber},{origin},{destination},{expectedTime},{null}" };
            File.WriteAllLines("flights.csv", lines);
        }
        else
        {
            string[] lines = { $"{flightNumber},{origin},{destination},{expectedTime},{specialCode}" };
            File.WriteAllLines("flights.csv", lines);
        }
        Console.WriteLine($"Flight {fl.FlightNumber} has been added!");

        //prompt user to add another flight
        Console.WriteLine("Would you like to add another flight? (Y/N)");
        string response = Console.ReadLine().ToUpper();
        if (response == "Y")
        {
            continue;
        }
        else if (response == "N")
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
            continue;
        }
    }
}

//List of Airlines for Changi Airport Terminal 5
void ListOfAirlines(Dictionary<string, string> airlinesDict)
{
    Console.WriteLine("=============================================" +
        "\nList of Airlines for Changi Airport Terminal 5" +
        "\n=============================================");
    Console.WriteLine($"{"Airline Code",-16}{"Airline Name"}");
    foreach (KeyValuePair<string, string> kvp in airlinesDict)
    {
        Console.WriteLine($"{kvp.Value,-16}{kvp.Key}");
    }
}

//Q7 - completed Ho Zhen Yi S10267291
void DisplayAirlineFlights(Dictionary<string, string> airlinesDict, Dictionary<string, Flight> flightsDict)
{
    Console.Write("Enter Airline Code: ");
    string airlineCode = Console.ReadLine().ToUpper();
    Console.WriteLine("\n=============================================");
    string airlineName = "";
    foreach (KeyValuePair<string, string> kvp in airlinesDict)
    {
        if (kvp.Value == airlineCode)
        {
            airlineName = kvp.Key; 
            break;
        }
    }
    if (airlinesDict.ContainsValue(airlineCode))
    {
        Console.WriteLine($"List of Flights for {airlineName}");
        Console.WriteLine("=============================================");
        Console.WriteLine($"{"Flight Number",-17}{"Airline Name",-23}{"Origin",-23}{"Destination",-20}{"Expected"}");
        foreach (Flight flight in flightsDict.Values)
        {
            if (flight.FlightNumber.Contains(airlineCode))
            {
                Console.WriteLine($"{flight.FlightNumber,-17}{airlineName,-23}{flight.Origin,-23}{flight.Destination,-20}{flight.ExpectedTime}");
            }
        }
        Console.WriteLine("\nEnter Flight Number to view details: ");
        string flightNumber = Console.ReadLine().ToUpper();

        if (flightsDict.ContainsKey(flightNumber))
        {
            Flight selectedFlight = flightsDict[flightNumber];
            Console.WriteLine($"\nFlight Details:");
            Console.WriteLine($"Flight Number: {selectedFlight.FlightNumber}");
            Console.WriteLine($"Airline: {airlineName}");
            Console.WriteLine($"Origin: {selectedFlight.Origin}");
            Console.WriteLine($"Destination: {selectedFlight.Destination}");
            Console.WriteLine($"Expected Departure/Arrival Time: {selectedFlight.ExpectedTime}");
            Console.WriteLine($"Special Request Code: {FlightAndSpecialCodeDict[flightNumber]}");
            Console.WriteLine($"Boarding Gate: {FlightNumToGate[flightNumber]}");
        }
        else
        {
            Console.WriteLine("Invalid Flight Number.");
        }
    }
    else
    {
        Console.WriteLine("Invalid Airline Code.");
    }
}

//Q8 - completed Ho Zhen Yi S10267291
void ModifyFlightDetailed(Dictionary<string, Flight> flightsDict, Dictionary<string, string> airlinesDict)
{
    Console.WriteLine("Enter Airline Code: ");
    string airlineCode = Console.ReadLine().ToUpper();
    string airlineName = "";
    foreach (KeyValuePair<string, string> kvp in airlinesDict)
    {
        if (kvp.Value == airlineCode)
        {
            airlineName = kvp.Key;
            break;
        }
    }
    if (airlinesDict.ContainsValue(airlineCode))
    {
        Console.WriteLine("\n=============================================");
        Console.WriteLine($"List of Flights for {airlineName}");
        Console.WriteLine("=============================================");
        Console.WriteLine($"{"Flight Number",-17}{"Airline Name",-23}{"Origin",-23}{"Destination",-20}{"Expected"}");
        foreach (Flight flight in flightsDict.Values)
        {
            if (flight.FlightNumber.Contains(airlineCode))
            {
                Console.WriteLine($"{flight.FlightNumber,-17}{airlineName,-23}{flight.Origin,-23}{flight.Destination,-20}{flight.ExpectedTime}");
            }
        }

        Console.WriteLine("\nChoose an existing Flight to modify or delete:");
        string flightNumber = Console.ReadLine().ToUpper();

        if (flightsDict.ContainsKey(flightNumber))
        {
            Console.WriteLine("1. Modify Flight Details");
            Console.WriteLine("2. Delete Flight");
            Console.WriteLine("Choose an option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Flight selectedFlight = flightsDict[flightNumber];
                Console.WriteLine("Select the detail to modify:");
                Console.WriteLine("1. Modify Basic Information");
                Console.WriteLine("2. Modify Status");
                Console.WriteLine("3. Modify Special Request Code");
                Console.WriteLine("4. Modify Boarding Gate");
                int moreOption = Convert.ToInt32(Console.ReadLine());

                if (moreOption == 1)
                {
                    Console.Write("Enter new Origin: ");
                    selectedFlight.Origin = Console.ReadLine();
                    Console.Write("Enter new Destination: ");
                    selectedFlight.Destination = Console.ReadLine();
                    Console.Write("Enter new Expected Departure/Arrival Time (dd/mm/yyyy hh:mm): ");
                    selectedFlight.ExpectedTime = Convert.ToDateTime(Console.ReadLine());
                }
                else if (moreOption == 2)
                {
                    Console.WriteLine("Enter a new Status (Delayed/Boarding/On Time): ");
                    selectedFlight.Status = Console.ReadLine();
                }
                else if (moreOption == 3)
                {
                    Console.WriteLine("Enter new Special Request Code (CFFT/DDJB/LWTT/None): ");
                    string newCode = Console.ReadLine().ToUpper();
                    FlightAndSpecialCodeDict[flightNumber] = newCode;
                }
                else if (moreOption == 4)
                {
                    Console.WriteLine("Enter new Boarding Gate: ");
                    string newGate = Console.ReadLine().ToUpper();
                    FlightNumToGate[flightNumber] = newGate;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
                Console.WriteLine("Flight updated!");
                Console.WriteLine($"Flight Number: {selectedFlight.FlightNumber}");
                Console.WriteLine($"Airline: {airlineName}");
                Console.WriteLine($"Origin: {selectedFlight.Origin}");
                Console.WriteLine($"Destination: {selectedFlight.Destination}");
                Console.WriteLine($"Expected Departure/Arrival Time: {selectedFlight.ExpectedTime}");
                Console.WriteLine($"Status: {selectedFlight.Status}");
                Console.WriteLine($"Special Request Code: {FlightAndSpecialCodeDict[flightNumber]}");
                Console.WriteLine($"Boarding Gate: {FlightNumToGate[flightNumber]}");
            }

            else if (option == "2")
            {
                Console.WriteLine("Are you sure you want to delete this flight? (Y/N)");
                string confirm = Console.ReadLine().ToUpper();

                if (confirm == "Y")
                {
                    flightsDict.Remove(flightNumber);
                    FlightAndSpecialCodeDict.Remove(flightNumber);
                    FlightNumToGate.Remove(flightNumber);
                    Console.WriteLine("Flight deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Deletion cancelled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }

        }
        else
        {
            Console.WriteLine("Invalid Flight Number.");
        }
    }
    else
    {
        Console.WriteLine("Invalid Airline Code.");
    }

}

//Q9 - completed Pang Ai Jie Jennie S10268150
void DisplayFlightSchedule(Dictionary<string, Flight> flightsDict, Dictionary<string, string> airlinesDict, Dictionary<string, string> FlightNumToGate)
{
    var sortedFlights = flightsDict.Values.ToList();
    sortedFlights.Sort();
    Console.WriteLine($"{"Flight Number",-16}{"Airline Name",-23}{"Origin",-23}{"Destination",-23}{"Expected Departure/Arrival Time",-36}{"Status",-16}{"Boarding Gate"}");
    foreach (KeyValuePair<string, Flight> kvp in flightsDict)
    {
        foreach (KeyValuePair<string, string> keyvaluepair in airlinesDict)
        {
            if (kvp.Value.FlightNumber.Contains(keyvaluepair.Value))
            {
                string airlineName = keyvaluepair.Key;
                Console.WriteLine($"{kvp.Value.FlightNumber,-16}{airlineName,-23}{kvp.Value.Origin,-23}{kvp.Value.Destination,-23}{kvp.Value.ExpectedTime, -36}{kvp.Value.Status, -16}{FlightNumToGate[kvp.Value.FlightNumber]}");
            }
        }
    }
}


//ADVANCE FEATURES
//(a) Process all unassigned flights to boarding gates in bulk - Completed but haven't tested - Pang Ai Jie Jennie S10268150
void ProcessUnassignedFlights(Dictionary<string, Flight> flightsDict, Dictionary<string, BoardingGate> boardinggateDict, Dictionary<string, string> FlightAndSpecialCodeDict, Dictionary<string, string> FlightNumToGate)
{
    //add unassigned flights to queue and display total number of unassigned flights
    Queue<Flight> unassignedFlights = new Queue<Flight>();
    foreach (KeyValuePair<string, Flight> Fkvp in flightsDict)
    {
        if (FlightNumToGate[Fkvp.Key] == "Unassigned")
        {
            unassignedFlights.Enqueue(Fkvp.Value);
        }
    }
    Console.WriteLine($"Total number of Flights that do not have any Boarding Gate assigned yet: {unassignedFlights.Count()}");

    //check if flight number has been assigned to boarding gate and display total number of unassigned boarding gates
    Dictionary<string, BoardingGate> unassignedBoardingGates = new Dictionary<string, BoardingGate>();
    foreach (KeyValuePair<string, BoardingGate> Bkvp in boardinggateDict)
    {
        if (Bkvp.Value.Flight == null)
        {
            unassignedBoardingGates.Add(Bkvp.Key, Bkvp.Value);
        }
    }
    Console.WriteLine($"Total number of Boarding Gates that do not have a Flight Number assigned yet: {unassignedBoardingGates.Count()}");

    //dequeue flight, check special request code, search unassigned boarding gate, assign gate to flight
    while (unassignedFlights.Count() != 0)
    {
        Flight unassigned = unassignedFlights.Dequeue();
        if (FlightAndSpecialCodeDict[unassigned.FlightNumber] == "DDJB")
        {
            foreach (KeyValuePair<string, BoardingGate> Bkvp in unassignedBoardingGates)
            {
                if (Bkvp.Value.SupportsDDJB == true)
                {
                    FlightNumToGate[unassigned.FlightNumber] = Bkvp.Key;
                    Bkvp.Value.Flight = unassigned;
                    unassignedBoardingGates.Remove(Bkvp.Key);
                    break;
                }
            }
        }
        else if (FlightAndSpecialCodeDict[unassigned.FlightNumber] == "CFFT")
        {
            foreach (KeyValuePair<string, BoardingGate> Bkvp in unassignedBoardingGates)
            {
                if (Bkvp.Value.SupportsCFFT == true)
                {
                    FlightNumToGate[unassigned.FlightNumber] = Bkvp.Key;
                    Bkvp.Value.Flight = unassigned;
                    unassignedBoardingGates.Remove(Bkvp.Key);
                    break;
                }
            }
        }
        else if (FlightAndSpecialCodeDict[unassigned.FlightNumber] == "LWTT")
        {
            foreach (KeyValuePair<string, BoardingGate> Bkvp in unassignedBoardingGates)
            {
                if (Bkvp.Value.SupportsLWTT == true)
                {
                    FlightNumToGate[unassigned.FlightNumber] = Bkvp.Key;
                    Bkvp.Value.Flight = unassigned;
                    unassignedBoardingGates.Remove(Bkvp.Key);
                    break;
                }
            }
        }
        else
        {
            foreach (KeyValuePair<string, BoardingGate> Bkvp in unassignedBoardingGates)
            {
                if (FlightAndSpecialCodeDict[unassigned.FlightNumber] == "None")
                {
                    FlightNumToGate[unassigned.FlightNumber] = Bkvp.Key;
                    Bkvp.Value.Flight = unassigned;
                    unassignedBoardingGates.Remove(Bkvp.Key);
                    break;
                }
            }
        }
    }

    //display the Flight details with Basic Information of all Flights
    Console.WriteLine($"{"Flight Number",-16}{"Airline Name",-23}{"Origin",-23}{"Destination",-23}{"Expected Departure/Arrival Time",-36}{"Special Request Code",-23}{"Boarding Gate"}");
    foreach (KeyValuePair<string, Flight> keyvaluepair in flightsDict)
    {
        Flight flight = keyvaluepair.Value;
        // finding airline name for the flight
        string airlineName = "";
        foreach (KeyValuePair<string, string> airlineKvp in airlinesDict)
        {
            if (flight.FlightNumber.Contains(airlineKvp.Value))
            {
                airlineName = airlineKvp.Key;
                break;
            }
        }
        // getting the special request code for the flight
        string specialCode;
        if (FlightAndSpecialCodeDict.ContainsKey(flight.FlightNumber))
        {
            specialCode = FlightAndSpecialCodeDict[flight.FlightNumber];
        }
        else
        {
            specialCode = "None";
        }

        // getting the boarding gate for the flight
        string boardingGate;
        if (FlightNumToGate.ContainsKey(flight.FlightNumber))
        {
            boardingGate = FlightNumToGate[flight.FlightNumber];
        }
        else
        {
            boardingGate = "Unassigned";
        }
        Console.WriteLine($"{flight.FlightNumber,-16}{airlineName,-23}{flight.Origin,-23}{flight.Destination,-23}{flight.ExpectedTime.ToString("dd/M/yyyy h:mm:ss tt"),-36}{specialCode,-23}{boardingGate}");

        //display the total number of Flights and Boarding Gates processed and assigned
        int totalFlightsProcessed = 0;
        int totalBoardingGatesProcessed = 0;
        foreach (KeyValuePair<string, Flight> kvp in flightsDict)
        {
            if (FlightNumToGate[kvp.Key] != "Unassigned")
            {
                totalFlightsProcessed++;
            }
        }
        foreach (KeyValuePair<string, BoardingGate> kvp in boardinggateDict)
        {
            if (kvp.Value.Flight != null)
            {
                totalBoardingGatesProcessed++;
            }
        }
        Console.WriteLine($"Total number of Flights processed and assigned: {totalFlightsProcessed}");

        //display the total number of Flights and Boarding Gates that were processed automatically over those that were already assigned as a percentage
        int percentageOfFlightsProcessed = (totalFlightsProcessed / flightsDict.Count()) * 100;
        int percentageOfBoardingGatesProcessed = (totalBoardingGatesProcessed / boardinggateDict.Count()) * 100;
        Console.WriteLine($"Total number of flights processed automatically: {percentageOfFlightsProcessed:0.00}%");
        Console.WriteLine($"Total number of boarding gates processed automatically: {percentageOfBoardingGatesProcessed:0.00}%");
    }
}

//(b) Display the total fee per airline for the day

//(c) Recommend an additional feature to be implemented (bonus marks are only awarded if the advanced feature is completed)

//main loop
while (true)
{
    Console.WriteLine("\n\n\n\n\n=============================================" +
        "\nWelcome to Changi Airport Terminal 5" +
        "\n=============================================" +
        "\n1. List All Flights" +
        "\n2. List Boarding Gates" +
        "\n3. Assign a Boarding Gate to a Flight" +
        "\n4. Create Flight" +
        "\n5. Display Airline Flights" +
        "\n6. Modify Flight Details" +
        "\n7. Display Flight Schedule" +
        "\n8. Process Unassigned Flights to Boarding Gates in Bulk" +
        "\n0. Exit");
    Console.WriteLine("\n\nPlease select your option:");
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
        Console.WriteLine($"{"Gate Name",-17}{"DDJB",-24}{"CFFT",-24}{"LWTT"}");
        ListBoardingGates(boardinggateDict);
    }
    else if (option == 3)
    {
        Console.WriteLine("=============================================" +
                            "\nAssign a Boarding Gate to a Flight" +
                            "\n=============================================");
        AssignBoardingGateToFlight(flightsDict, boardinggateDict, FlightAndSpecialCodeDict);
    }
    else if (option == 4)
    {
        CreateFlight(flightsDict);
    }
    else if (option == 5)
    {
        ListOfAirlines(airlinesDict);
        DisplayAirlineFlights(airlinesDict, flightsDict);
    }
    else if (option == 6)
    {
        ListOfAirlines(airlinesDict);
        ModifyFlightDetailed(flightsDict, airlinesDict);
    }
    else if (option == 7)
    {
        Console.WriteLine("=============================================" +
            "\nFlight Schedule for Changi Airport Terminal 5" +
            "\n=============================================");
        DisplayFlightSchedule(flightsDict, airlinesDict, FlightNumToGate);
    }
    else if (option == 8)
    {
        //ProcessUnassignedFlights(flightsDict, boardinggateDict, FlightAndSpecialCodeDict, FlightNumToGate);
    }
    else if (option == 0)
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    else
    {
        Console.WriteLine("Invalid option. Please try again.");
    }
}