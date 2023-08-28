using BabyfootAPI.Models;
using BabyfootAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace STIVE_API.Controllers.Ressources
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RankController : ControllerBase
    {
        private readonly IRankServices _rankServices;
        public RankController(IRankServices rankServices)
        {
            _rankServices = rankServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetRanks()
        {
            var result = await _rankServices.GetRanks();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetRankById(int rankId)
        {
            var result = await _rankServices.GetRankById(rankId);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRank([FromBody]Rank rank)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var result = await _rankServices.AddRank(rank);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        public async Task<Rank> UpdateRank(Rank rank)
        {
            try
            {
                if (rank.Id > 0)
                {
                    var result = await _rankServices.UpdateRank(rank);
                    return result;
                }
                else
                {
                    throw new Exception($"L'objet de type {nameof(Rank)} n'existe pas");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteRank(int rankId)
        {
            var result = await _rankServices.RemoveRank(rankId);
            return Ok(result);
        }

    }
}
