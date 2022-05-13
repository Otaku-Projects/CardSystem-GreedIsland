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


        private readonly IUnitOfWork unitOfWork;

        public CardController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
             
            //this.repository = new GenericRepository<Card>(context);

            //this.repository = this.unitOfWork.CardRepository;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            try
            {
                var query = this.unitOfWork.Card.GetAll();

                var result = query.ToList();

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
                //var query = _context.Card
                //    .Where(c => c.Id.Equals(cardID))
                //    .Include("CardContents")
                //    .FirstOrDefault();
                //var query = this.repository.GetById(f => f.Id.Equals(cardID));


                //var query = this.unitOfWork.Card.GetById(
                //    f => f.Id.Equals(cardID),
                //    includeProperties: "CardContent"
                //    );
                var query = this.unitOfWork.Card.GetById(
                    f => f.Id.Equals(cardID),
                    includeProperties: "CardContents"
                    );
                var query2 = this.unitOfWork.Card.GetById(f=>f.Id.Equals(cardID))
                    .Include("CardContents");


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

        [HttpPost]
        public IActionResult Insert(Card card)
        {
            if (card != null)
            {
                //repository.Insert(card);
                //repository.Save();
                this.unitOfWork.Card.Insert(card);
                this.unitOfWork.Card.Save();
                return StatusCode(200);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Card card)
        {
            if (card != null)
            {
                //repository.Update(card);
                //repository.Save();
                this.unitOfWork.Card.Update(card);
                this.unitOfWork.Card.Save();
                return RedirectToAction("Get", new { cardId = card.Id });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int cardID)
        {
            if (cardID != null && cardID >=0)
            {
                //repository.Delete(cardID);
                //repository.Save();
                this.unitOfWork.Card.Delete(cardID);
                this.unitOfWork.Card.Save();
                return RedirectToAction("Get", new { cardId = cardID });
            }
            return BadRequest();
        }
    }
}