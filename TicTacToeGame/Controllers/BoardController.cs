using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicTacToeGame.Models;

namespace TicTacToeGame.Controllers
{
    public class BoardController : ApiController
    {
        static Board board = new Board();
        static int countOfTimesBoardIsCalled=0;//odd calls are by player 1 and even calls are by player 2 

        // GET: api/Board
        public String Get()
        {
            String boardview = "\r\n";
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 3; colIndex++) 
                {
                    boardview = boardview + board.boardcoordinates[rowIndex,colIndex];
                }
                boardview = boardview + "\r\n";
            }
            return boardview;
        }

        // GET: api/Board/5
        public string Get(int id)
        {
            int rowCoordinate = (id % 10) - 1;
            int colCoordinate = (id / 10) - 1;
            return board.boardcoordinates[colCoordinate, rowCoordinate] + "";
        }

        // PUT: api/Board/5
        public String Put(int id)
        {
            int rowCoordinate = (id % 10) - 1;
            int colCoordinate = (id / 10) - 1;
            countOfTimesBoardIsCalled++;
            if (countOfTimesBoardIsCalled % 2 != 0) //player 1's turn
            {
                board.boardcoordinates[colCoordinate, rowCoordinate] = 'O';
                if (ifItsAwin('O')==1)
                {
                    resetBoard();
                    return "Player 1 wins, board has been resetted";
                }
            }
            else //playes 2's turn
            {
                board.boardcoordinates[colCoordinate, rowCoordinate] = 'X';
                if (ifItsAwin('X') == 1)
                {
                    resetBoard();
                    return "Player 2 wins, board has been resetted";      
                }
            }
            if (isNobodyWins()==1)
            {
                resetBoard();
                return "Nobody wins, board has been resetted";
            }
            return null;
        }

        public static void resetBoard()
        {
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 3; colIndex++)
                {

                    board.boardcoordinates[rowIndex, colIndex] = '-';
                }
            }
            countOfTimesBoardIsCalled = 0;
        }

        public static int isNobodyWins()
        {
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 3; colIndex++)
                {

                    if(board.boardcoordinates[rowIndex, colIndex] == '-')
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }

        public static int ifItsAwin(Char currentPlayersSymbol)
        {
            //row 1 win
            if (board.boardcoordinates[0, 0] == currentPlayersSymbol && board.boardcoordinates[0, 1] == currentPlayersSymbol && board.boardcoordinates[0, 2] == currentPlayersSymbol)
            {
                return 1;
            }
            //row 2 win
            if (board.boardcoordinates[1, 0] == currentPlayersSymbol && board.boardcoordinates[1, 1] == currentPlayersSymbol && board.boardcoordinates[1, 2] == currentPlayersSymbol)
            {
                return 1;
            }
            //row 3 win
            if (board.boardcoordinates[2, 0] == currentPlayersSymbol && board.boardcoordinates[2, 1] == currentPlayersSymbol && board.boardcoordinates[2, 2] == currentPlayersSymbol)
            {
                return 1;
            }
            //column 1 win
            if (board.boardcoordinates[0, 0] == currentPlayersSymbol && board.boardcoordinates[1, 0] == currentPlayersSymbol && board.boardcoordinates[2, 0] == currentPlayersSymbol)
            {
                return 1;
            }
            //column 2 win
            if (board.boardcoordinates[0, 1] == currentPlayersSymbol && board.boardcoordinates[1, 1] == currentPlayersSymbol && board.boardcoordinates[2, 1] == currentPlayersSymbol)
            {
                return 1;
            }
            //column 3 win
            if (board.boardcoordinates[0, 2] == currentPlayersSymbol && board.boardcoordinates[1, 2] == currentPlayersSymbol && board.boardcoordinates[2, 2] == currentPlayersSymbol)
            {
                return 1;
            }
            //diagonal win 1
            if (board.boardcoordinates[0, 0]==currentPlayersSymbol && board.boardcoordinates[1, 1]==currentPlayersSymbol && board.boardcoordinates[2, 2]==currentPlayersSymbol)
            {
                return 1;
            }
            //diagonal win 2
            if (board.boardcoordinates[0,2]==currentPlayersSymbol && board.boardcoordinates[1,1]==currentPlayersSymbol && board.boardcoordinates[2,0]==currentPlayersSymbol)
            {
                return 1;
            }
            return 0;
        }

        // POST: api/Board
        public void Post([FromBody]String ids)
        {
        }

        // DELETE: api/Board/5
        public void Delete(int id)
        {
        }
    }
}
