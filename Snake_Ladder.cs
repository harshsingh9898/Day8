using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_Programming
{
    public class Snake_Ladder
    {
        public static void game()
        {

           int j=30;//initial position on player by start variable
            while(j>=7)
            {
                int start = 0, i = 0;

            repeat1:
                Random random = new Random();   //rolling the die
                int roll = random.Next(1, 7);
                i++;                //count the number of rolls
                if (roll == 1 || roll == 6)  //player will start when he gets 1 or 6
                {
                    start = 1;  //player will start from 1
                    while (start != 100)  //till player's position is not 100
                    {
                    repeat2:
                        Random random2 = new Random();
                        int roll2 = random2.Next(1, 7);// to move players position with every roll
                        i++;          //count the number of rolls

                        start += roll2;
                        if (start == 3)        //ladder from 3 to 90
                        {
                            start = 90;
                        }
                        else if (start == 56)     //ladder from 56 to 76
                        {
                            start = 76;
                        }
                        else if (start == 99)    //snake from 99 to 10
                        {
                            start = 10;

                        }
                        else if (start == 30)   //snake from 30 to 20
                        {
                            start = 20;
                        }
                        else if (start == 20)    //snake from 20 to 5
                        {
                            start = 5;
                        }
                        if(start<100)Console.WriteLine("Position after " + i + " die roll " + start);
                        else Console.WriteLine("Position after " + i + " die roll " + (start-roll2));
                        if (start > 100)      //to get exact number to go to 100
                        {
                            start -= roll2;
                            goto repeat2;
                        }
                    }
                }
                if (start == 0) { goto repeat1; }      //if die does not show 1 or 6 then start again 
                Console.WriteLine("The number of times dice rolled to win the game is: " + i);
                j = i;
            }


        }
    }
}
