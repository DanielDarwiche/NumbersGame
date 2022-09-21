using System;

namespace NumbersGame
{
    class Program
    {
        static void GameMenu()
        {
            bool play = true;
            do //skapar en loop som funkar frågar om man vill spela igen, efter man spelat
            {
                Console.Clear();//Rensar konsollen vid omstart av spelet
                Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1 och 20. ");
                Console.WriteLine("Ange en siffra för hur många gånger du kan gissa:");

                GuessingMethod();  //Här inropas GuessingMethod-metoden. 

                Console.WriteLine("Vill du spela igen?");
                Console.WriteLine("JA: Tryck 1");//trycks 1 så spelar man igen för loopen fortsätter
                Console.WriteLine("NEJ: Tryck valfri siffra. ");//trycker man 2 avbryts loopen, trycker man annat kraschar prog. 
                int answer = int.Parse(Console.ReadLine());
                if (answer == 1)//if sats för att välja om man ska spela, som avbryter loopen
                {
                    play = true;
                }
                else
                {
                    play = false;
                }
            } while (play);

        }                                
        static void Main(string[] args)
        {
            GameMenu();//Main kör GameMenu-metoden som har GuessingMethod-metoden i sig 
        }
        static void GuessingMethod()
        {
            Random RandomNumber = new Random();
            int number = RandomNumber.Next(1, 20);  //tilldelar ett random värde i en variabel 

            int amTry = int.Parse(Console.ReadLine());//anger antal gissningsförsök i variabeln amTry
            Console.WriteLine("Du valde {0} gissningar. Varsågod och gissa!", amTry);
            for (int i = 1; i <= amTry; i++)
            {//loopar spelmöjligheten antal gånger man har angett.medan i är mindre än eller lika med amTry, ökar i
                int guess = int.Parse(Console.ReadLine());//läser in gissning till int guess
                if (guess == number)
                {//om svaret är rätt skrivs detta och spelet avbryts                            
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Woho! Du gjorde det! {0} är rätt.", guess);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else if (guess < number && guess < 21 && guess > 0)
                {//Om gissningen är mindre än nr och 1-20 skrivs detta
                    Console.WriteLine("Tyvärr du gissade för lågt!");
                }
                else if (guess > number && guess < 21 && guess > 0)
                {//Om gissningen är större än nr och 1-20 skrivs detta
                    Console.WriteLine("Tyvärr du gissade för högt!");
                }
                else
                { //Om gissningen är större än 20 eller mindre än 1 skrivs detta
                    Console.WriteLine("Inmatad sekvens var fel. " + "Var god gissa på ett tal mellan 1 och 20.");
                }
                if (amTry == i) //om antalet gissningar blir lika med i, vilket är samma, så skrivs detta ut
                {//Det skrivs lltid ut, om nite man gissat rätt, för gissar man rätt avbryts spelomgången
                    Console.WriteLine("Tyvärr du lyckades inte gissa talet på {0} försök!",amTry);
                }
            }
        }
    }
}
