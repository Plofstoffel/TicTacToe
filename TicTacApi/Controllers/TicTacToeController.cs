using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicTacToe;
using TicTacToe.Enums;

namespace TicTacApi.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    public class TicTacToeController : Controller
    {
        
        /// <summary>
        /// Starts a new game.
        /// </summary>
        /// <response code="200">Game Created</response>
        /// <response code="500">Oops! Skynet is taking over!!!</response>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Board))]
        [ProducesResponseType(500)]
        [Route("StartGame")]
        public IActionResult StartGame()
        {
            try
            {
                Board currentBoard = new Board();                
                return Ok(currentBoard);
            }
            catch (Exception)
            {
                //Todo: Impliment Logging;
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Make a Move!
        /// </summary>       
        /// <response code="200">Move made</response>
        /// <response code="404">No Current Game</response>
        /// <response code="500">Oops! Skynet is taking over!!!</response>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GameState))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("Play")]
        public IActionResult Play([FromBody]PlayObject playObject)
        {
            try
            {
                var gameBoard = JsonConvert.DeserializeObject<Board>(playObject.gameBoard);
                if (gameBoard == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(gameBoard.Play((Marker)playObject.marker, playObject.position));
                }
            }
            catch (Exception)
            {
                //Todo: Impliment Logging;
                return StatusCode(500);
            }
        }

    }

    public class PlayObject
    {
        public string gameBoard { get; set; }
        public int marker { get; set; }
        public int position { get; set; }
    }
}
