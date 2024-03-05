using System;

namespace App{
    class Program{
        static void Main(string[] args)
        {
            //Interface 
            Console.WriteLine("1. Chopping, Cutting");
            Console.WriteLine("2. Arctan Taylor Series");
            string choice = Console.ReadLine();

            switch(choice){
                case "1":
                    //arctan taylor's P

                    //input for domain and degree
                    Console.Write("Enter Domain(x):");
                    double domain = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Degree: ");
                    double degree = Convert.ToDouble(Console.ReadLine());

                    //Print Out Approximated Value
                    Console.WriteLine("Approx. Value: " + taylorSeriesMake(domain,degree)); 
                    break;
                case "2":
                    //Chopping and Cutting
                    Console.Write("Enter Float: ");
                    string trueValue = Console.ReadLine();
                    break;
            }

            

            
        }

        static double[] chopAndRound(string decim){
            double[] chopAndRound = new double[2];
            string[] chopString = new string[2];
            try{
                chopString = decim.Split(".");
            }catch(Exception e){
                chopString[0] = decim;
                chopString[1] = "00";
            }
            

            return chopAndRound;
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
