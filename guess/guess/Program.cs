
class A
{
    static void Main()
    {
        //enter min number
        Console.WriteLine("enter Min: \n");
        int min = int.Parse(Console.ReadLine());

        //enter max number
        Console.WriteLine("enter Max: \n");
        int max = int.Parse(Console.ReadLine());
        
        //setup the number and game
        A a = new A(min, max);
        //can guess 5 times
        int tryTime = 5;

        //game start
        while (tryTime != 0)
        {
            // enter guess number
            Console.WriteLine("take a guess: ");
            int guess = int.Parse(Console.ReadLine());

            //guess number is the number win the game and exit
            if (guess == a.getNum())
            {
                Console.WriteLine("Win \n");
                break;
            }
            else
            {
                //hint
                if (guess > a.getNum())
                {
                    Console.WriteLine("too high");
                }
                else
                {
                    Console.WriteLine("too low");
                }
            }
            tryTime--;//times -1
        }

        //after 5 times, still not get the number lose the game
        if (tryTime == 0)
        {
            Console.WriteLine("lose");
        }
    }

    private int min, max, num;
    
    public A(int min, int max)
    {
        this.min = min;
        this.max = max;
        Random random = new Random();
        this.num = random.Next(min,max);
    }

    public int getNum()
    {
        return num;
    }
   
}
