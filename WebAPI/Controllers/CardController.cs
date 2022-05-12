using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebAPI.DataContext;
using WebAPI.DataModel;
using WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [AllowAnonymous]
    public class CardController : BaseController
    {
        private readonly CardSystemDataContext _context;
        private IGenericRepository<Card> repository = null;
        public CardController(CardSystemDataContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            try
            {
                var cards = _context.Card;

                var result = cards.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        // GET api/values
        [HttpGet("Get/{cardID:int}")]
        public IActionResult GetWithDetails(int cardID)
        {
            try
            {
                var query = _context.Card
                    .Where(c => c.Id.Equals(cardID))
                    .Include("CardContents")
                    .FirstOrDefault();

                if (query == null)
                {
                    return NotFound();
                }
                else
                {
                    //var result = _mapper.Map<EmployeeEntity>(employee);
                    //var result = query.ToList();
                    return Ok(query);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }
    }
}