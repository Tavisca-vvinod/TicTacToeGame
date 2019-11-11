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

        // GET: api/Board
        public String Get()
        { 
            return BoardFunctions.ReturnBoardView(board);
        }

        // GET: api/Board/11
        public string Get(int id)
        {
            return BoardFunctions.ReturnBoardField(id, board);
        }

        // PUT: api/Board/11
        public String Put(int id)
        {
            return BoardFunctions.Play(id, board);
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
