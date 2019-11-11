using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToeGame.Models
{
    public class Board
    {
        public Char[,] boardcoordinates = new Char[3, 3];
        public int countOfTimesBoardIsCalled;

        public Board()
        {
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 3; colIndex++)
                {
                    
                    boardcoordinates[rowIndex, colIndex] = '-';
                }
            }
        }
    }
}
