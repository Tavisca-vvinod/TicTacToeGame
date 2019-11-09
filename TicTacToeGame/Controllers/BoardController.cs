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
            String boardview = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++) 
                {
                    boardview = boardview + board.boardcoordinates[i,j];
                }
                boardview = boardview + "\n";
            }
            return boardview;
        }

        // GET: api/Board/5
        public string Get(int id)
        {
            int y = (id % 10) - 1;
            int x = (id / 10) - 1;
            return board.boardcoordinates[x, y] + "";
        }

        // PUT: api/Board/5
        public void Put(int id)
        {
            int y = (id % 10) - 1;
            int x = (id / 10) - 1;
            countOfTimesBoardIsCalled++;
            if (countOfTimesBoardIsCalled % 2 != 0)//player 1's turn
            {
                board.boardcoordinates[x, y] = 'O';
            }
            else //playes 2's turn
            {
                board.boardcoordinates[x, y] = 'X';
            }
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
