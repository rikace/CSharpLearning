using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using WorkshopVary.FlightQuery;

namespace WorkshopVary
{    
    class Program
    {
        static void RunFlightQuery(IFlightsLoader fetchData)
        {
            // download data
            // parse the data 

            var flights = fetchData.Load();

            // create instance query/filter object 
            // add filters
            // run query
            // get data
            FlightsQuery query = new FlightsQuery(flights);

            query.AddFilter(QueryCriteriaType.Destination, "Basel");
            query.AddFilter(QueryCriteriaType.Origin, "London");

            var myFlights = query.Execute();

            foreach (var myFlight in myFlights)
            {
                Console.WriteLine($"Flight with destination to {myFlight.Destination}");
            }
        }


        static void Main(string[] args)
        {
            // - Flight CSV query            
            //string filePath = "./HMT_-_2011_Air_Data.csv";
            //var dataLoader = new FlightsLoader(filePath);
            //RunFlightQuery(dataLoader);


            // - Tic Tac Toe 
            /*
                __|__|__
                __|__|__
                  |  |        
             */

            var player1 = new Player("Kavya", 'X');
            var player2 = new Player("Padma", 'O');

            var game = new TicTacToeGame(player1, player2);
            game.Play();


            Console.ReadLine();
        }
    }
}
