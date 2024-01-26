
public class Program
{

    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1;
    static int flag = 0;
    static int choice;

    public static void Main(string[] args)
    {



        Console.Write("(Press (1) to play against a friend or Press (2) to play against a computer): ");
        int userChoice = int.Parse(Console.ReadLine());

        while (userChoice != 1 && userChoice != 2)
        {
            Console.Write("Invalid number. Please try again: ");
            userChoice = int.Parse(Console.ReadLine());

        }

        if (userChoice == 1)
        {

            PlayFriend();



        }
        else if (userChoice == 2)
        {

            Console.WriteLine("Player vs CPU");

            PlayCpu();



        }


    }


    public static void PlayFriend()
    {

        do
        {

            PrintBoard();


            bool userInput = false;

            if (player % 2 == 0)
            {
                Console.Write("Player 2(O) turn: ");
            }
            else
            {
                Console.Write("Player 1(X) turn: ");
            }

            while (!userInput)
            {
                userInput = int.TryParse(Console.ReadLine(), out choice);

                if (!userInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                {
                    Console.Write("Invalid input. Please enter a vaild number: ");
                    userInput = false;


                }

            }

            if (player % 2 == 0)
            {
                board[choice - 1] = 'O';
                player++;
            }
            else
            {
                board[choice - 1] = 'X';
                player++;
            }




            flag = CheckForWin();


            if (flag == 1)
            {
                if (player % 2 == 0)
                {

                    PrintBoard();
                    Console.WriteLine("Player 1(X) Wins!");

                }
                else
                {

                    PrintBoard();
                    Console.WriteLine("Player 2(O) Wins!");
                }

            }
            else if (flag == 2)
            {
                Console.WriteLine("Tie Game!");
            }




        } while (flag == 0);

    }

    public static void PlayCpu()
    {


        Random random = new Random();



        do
        {

            PrintBoard();




            if (player % 2 == 0)
            {
                Console.Write("Player 2(O) turn: ");
                int computerTurn;

                do
                {

                    computerTurn = random.Next(0, 8);

                } while (board[computerTurn] == 'X' || board[computerTurn] == 'O');

                board[computerTurn] = 'O';
                player++;

            }
            else
            {
                Console.Write("Player 1(X) turn: ");
                bool userInput = false;

                while (!userInput)
                {
                    userInput = int.TryParse(Console.ReadLine(), out choice);

                    if (!userInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                    {
                        Console.Write("Invalid input. Please enter a vaild number: ");
                        userInput = false;


                    }

                }

                board[choice - 1] = 'X';
                player++;
            }


            flag = CheckForWin();


            if (flag == 1)
            {
                if (player % 2 == 0)
                {

                    PrintBoard();
                    Console.WriteLine("Player 1(X) Wins!");

                }
                else
                {

                    PrintBoard();
                    Console.WriteLine("Player 2(O) Wins!");
                }

            }
            else if (flag == 2)
            {
                Console.WriteLine("Tie Game!");
            }



        } while (flag == 0);

    }

    private static void PrintBoard()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
        Console.WriteLine("     |     |      ");
    }




    public static int CheckForWin()
    {

        // horizonal winner
        if (board[0] == board[1] && board[1] == board[2])
        {
            return 1;

        }
        else if (board[3] == board[4] && board[4] == board[5])
        {
            return 1;

        }
        else if (board[6] == board[7] && board[7] == board[8])
        {
            return 1;

        }

        // vertical winner 
        if (board[0] == board[3] && board[3] == board[6])
        {
            return 1;

        }
        else if (board[1] == board[4] && board[4] == board[7])
        {
            return 1;

        }
        else if (board[2] == board[5] && board[5] == board[8])
        {
            return 1;

        }


        // diagonal winner
        if (board[0] == board[4] && board[4] == board[8])
        {
            return 1;

        }
        else if (board[2] == board[4] && board[4] == board[6])
        {
            return 1;

        }

        //tie


        if (board[0] != '1' && board[1] != '2' && board[2] != '3' && board[3] != '4' && board[4] != '5' && board[5] != '6' && board[6] != '7' && board[7] != '8' && board[8] != '9')
        {
            return 2;
        }

        return 0;

    }
}


