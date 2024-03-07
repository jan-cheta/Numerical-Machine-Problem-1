using System;
//Please Add this line below because I used Dictionaries for our functions
using System.Collections.Generic; 

namespace App{
    class Program{
        static void Main(string[] args)
        {
            //Interface 
            Console.WriteLine("Choose Function: ");
            Console.WriteLine("1. Arctan Taylor Series");
            Console.WriteLine("2. Chopping, Cutting");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch(choice){
                case "1":
                    //arctan taylor's P

                    //input for domain and degree
                    Console.Write("Enter Domain(x):");
                    double domain = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Degree: ");
                    double degree = Convert.ToDouble(Console.ReadLine());

                    //print out approximated value and errors
                    double taylorAV = taylorSeriesMake(domain,degree);
                    double taylorTV = Math.Atan(domain);
                    Console.WriteLine("True Value: " + taylorTV);
                    Console.WriteLine("Approx. Value: " + taylorAV);
                    Console.WriteLine("Absolute Error: " + errorFind(taylorTV,taylorAV)["Absolute Error"]);
                    Console.WriteLine("Relative Error: " + errorFind(taylorTV,taylorAV)["Relative Error"] + "%");
                    break;
                case "2":
                    //Chopping and Cutting

                    //input for float and decimal places
                    Console.Write("Enter Float: ");
                    double trueValue = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Decimal Places: ");
                    int demPlaces = Convert.ToInt16(Console.ReadLine());

                    //print out chopped value and errors
                    double chopped = chopAndRound(Convert.ToString(trueValue), demPlaces)["Chopping"];
                    decimal chopAE = errorFind(trueValue, chopped)["Absolute Error"];
                    decimal chopRE = errorFind(trueValue, chopped)["Relative Error"];
                    Console.WriteLine("--------------Chopping---------------");
                    Console.WriteLine("Chopped: " + chopped);
                    Console.WriteLine("Absolute Error: " + chopAE);
                    Console.WriteLine("Relative Error: " + chopRE + "%");

                    //print out rounded value and errors
                    double rounded = chopAndRound(Convert.ToString(trueValue), demPlaces)["Rounding"];
                    decimal roundAE = errorFind(trueValue, rounded)["Absolute Error"];
                    decimal roundRE = errorFind(trueValue, rounded)["Relative Error"];
                    Console.WriteLine("--------------Rounding---------------");
                    Console.WriteLine("Rounded: " + rounded);
                    Console.WriteLine("Absolute Error: " + roundAE);
                    Console.WriteLine("Relative Error: " + roundRE + "%");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            

            
        }

        static Dictionary<string,double> chopAndRound(string decim, int decPlaces){
            Dictionary<string, double> chopAndRound = new Dictionary<string, double>();
            
            //Chopping Value
            string[] chopString = new string[2];
            try{
                chopString = decim.Split(".");
            }catch{
                chopString[0] = decim;
                chopString[1] = "00";
            }
            string choppedDecimal = chopString[1][..decPlaces];
            double choppedValue = Convert.ToDouble(chopString[0] + "." + choppedDecimal);
            chopAndRound.Add("Chopping", choppedValue);

            //Rounding Value
            double roundedValue = Math.Round(Convert.ToDouble(decim),decPlaces);
            chopAndRound.Add("Rounding", roundedValue);
            
            return chopAndRound;
        }

        static Dictionary<string,decimal> errorFind(double trueValue, double approxValue){
            Dictionary<string, decimal> errorFound = new Dictionary<string, decimal>();
            decimal trueDeciValue = Convert.ToDecimal(trueValue);
            decimal approxDeciValue = Convert.ToDecimal(approxValue);

            //Find Absolute Error
            decimal absoluteError = Math.Abs(trueDeciValue - approxDeciValue);
            errorFound.Add("Absolute Error", absoluteError);

            //Find Relative Error
            decimal relativeError = (absoluteError/trueDeciValue)*100;
            errorFound.Add("Relative Error", relativeError);

            return errorFound; 
        }
        static double taylorSeriesMake(double domain, double degree){
            double taylorSeries = 0;
            if(domain<1 & domain>0){
                for(int i = 0; i<=degree; i++){
                    taylorSeries += (Math.Pow(-1,i)*(Math.Pow(domain,(2*i)+1)))/((2*i)+1);
                }
            }else if(domain>=1){
                taylorSeries = (Math.PI*domain)/(2*domain);
                Console.WriteLine("big than one");
                for(int i = 0; i<=degree; i++){
                    taylorSeries += (Math.Pow(-1,i+1))/(Math.Pow(domain*((2*i)+1),(2*i)+1));
                }
            }
            return taylorSeries;
        }
    }
}
