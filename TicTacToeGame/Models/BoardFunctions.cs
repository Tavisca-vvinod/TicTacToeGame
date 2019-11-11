using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToeGame.Models
{
    public class BoardFunctions
    {
        public static String ReturnBoardView(Board board)
        {
            String boardview = "\n";
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 3; colIndex++)
                {
                    boardview = boardview + board.boardcoordinates[rowIndex, colIndex];
                }
                boardview = boardview + "\n";
            }
            return boardview;
        }

        public static String ReturnBoardField(int coordinates, Board board)
        {
            int rowCoordinate = (coordinates % 10) - 1;
            int colCoordinate = (coordinates / 10) - 1;
            return board.boardcoordinates[colCoordinate, rowCoordinate] + "";
        }

        public static String Play(int coodinates, Board board)
        {
            int rowCoordinate = (coodinates % 10) - 1;
            int colCoordinate = (coodinates / 10) - 1;
            board.countOfTimesBoardIsCalled++;
            if (board.countOfTimesBoardIsCalled % 2 != 0) //player 1's turn
            {
                board.boardcoordinates[colCoordinate, rowCoordinate] = 'O';
                if (IfItsAwin('O',board) == 1)
                {
                    ResetBoard(board);
                    return "Player 1 wins, board has been resetted";
                }
            }
            else //playes 2's turn
            {
                board.boardcoordinates[colCoordinate, rowCoordinate] = 'X';
                if (IfItsAwin('X',board) == 1)
                {
                    ResetBoard(board);
                    return "Player 2 wins, board has been resetted";
                }
            }
            if (IsNobodyWins(board) == 1)
            {
                ResetBoard(board);
                return "Nobody wins, board has been resetted";
            }
            return null;
        }

        public static void ResetBoard(Board board)
        {
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 3; colIndex++)
                {

                    board.boardcoordinates[rowIndex, colIndex] = '-';
                }
            }
            board.countOfTimesBoardIsCalled = 0;
        }

        public static int IsNobodyWins(Board board)
        {
            for (int rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 3; colIndex++)
                {

                    if (board.boardcoordinates[rowIndex, colIndex] == '-')
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }

        public static int IfItsAwin(Char currentPlayersSymbol, Board board)
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
            if (board.boardcoordinates[0, 0] == currentPlayersSymbol && board.boardcoordinates[1, 1] == currentPlayersSymbol && board.boardcoordinates[2, 2] == currentPlayersSymbol)
            {
                return 1;
            }
            //diagonal win 2
            if (board.boardcoordinates[0, 2] == currentPlayersSymbol && board.boardcoordinates[1, 1] == currentPlayersSymbol && board.boardcoordinates[2, 0] == currentPlayersSymbol)
            {
                return 1;
            }
            return 0;
        }

    }
}