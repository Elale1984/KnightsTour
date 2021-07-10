using System;

namespace KnightsTour
{
    class Program
    {
        static int BoardSize = 8;
        static int attemptedMoves = 0;
        
        //checkNeighbors list for waldo
        
        
        /*
         * the xMove[] and yMove[] will be the x an y coordinates
         * the the next move will be.
         */
        static int[] xMove = {2, 1, -1, -2, -2, -1, 1, 2};
        static int[] yMove = {1, 2, 2, 1, -1, -2, -2, -1};
        
        //grid is 8x8 and all spaces that have not been visited are set to -1
        static int[,] boardGrid = new int[BoardSize, BoardSize];
        
        //Driver code
        static void Main(string[] args)
        {
            SolveKt();
            Console.ReadLine();
        }

   
        /*
         * This method is used to solve the knights tour problem using
         * bracketing. A method call to solveKTUntil() is used to solve
         * the problem. returns false if no complete tour is possible else
         * it returns true and prints the tour. More than one solution is
         * possible.
         */
        static void SolveKt()
        {
            //fills the grid with int value of -1 for each space for not visited
            for (int x = 0; x < BoardSize; x++)
            {
                for (int y = 0; y < BoardSize; y++)
                {
                    boardGrid[x, y] = -1;
                }
                
            }
                
            // Starting positions for boardGrid[x,y]    
            int startX = 4;
            int startY = 0;
            
            //setting the starting position of the Knight
            boardGrid[startX, startY] = 0;
            
            // reset guess count
            attemptedMoves = 0;
           
            
            // look for all possible tours
            if (!SolveKtUtil(startX, startY, 1))
            {
                Console.Write("Solution does not exist for {0} and {1}",startX,startY);
            }
            else
            {
                PrintSolution(boardGrid);
                Console.Out.WriteLine("Total attempted moves {0}" , attemptedMoves);
                
            }
            
        }
        
        // Recursive utility function to solve Knight Tour Problem
        static bool SolveKtUtil(int x, int y, int moveCnt)
        {
            attemptedMoves++;
            
            // prints update every million attempts
            if (attemptedMoves % 10000000 == 0) Console.WriteLine("Attempts: {0}", attemptedMoves);

            int k; //counter 
            int next_x, next_y; // location
            
            //check to see if solution has been found
            if (moveCnt == BoardSize * BoardSize)
                return true;
            
            // Try all next moves from the current coordinate x,y
            for (k = 0; k < 8; k++)
            {
                //creating the next move
                next_x = x + xMove[k];
                next_y = y + yMove[k];

               
                if (IsSquareSafe(next_x, next_y))
                {
                    
                    // if safe, set the cell to the move count
                    boardGrid[next_x, next_y] = moveCnt;
                    if (SolveKtUtil(next_x, next_y, moveCnt + 1))
                    {
                        return true;
                    }
                    else
                    {
                        boardGrid[next_x, next_y] = -1; // back tracking
                    }
                        
                }
            }
           

            return false;
        }
        
       

        // utility method to check if i,j are valid indexes for n*n chessboard
        static bool IsSquareSafe(int x, int y)
        {
            // check for out of bounds of board
            //check for visit of -1
            return (x >= 0 && x < BoardSize &&
                    y >= 0 && y < BoardSize &&
                    boardGrid[x, y] == -1);
        }

        // utility method to print solution matrix sol[n][n]
        static void PrintSolution(int[,] solution)
        {
            for (int x = 0; x < BoardSize; x++)
            {
                for (int y = 0; y < BoardSize; y++)
                {
                    if (boardGrid[x, y] < 10)
                        Console.Write(" ");
                    Console.Write(solution[x, y] + " ");
                }

                Console.WriteLine();
                
            }
        }
    }
}