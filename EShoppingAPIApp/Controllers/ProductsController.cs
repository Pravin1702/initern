using EShoppingAPIApp.Models;
using EShoppingAPIApp.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]

    public class ProductsController : ControllerBase
    {
        private IRepo<int, Products> _repo;

        public ProductsController(IRepo<int, Products> repo)
        {
            _repo = repo;
        }
        // Create
        [HttpPost]
        [Route("Product_Adding")]

        public ActionResult<Products> Create(Products products)
        {
            var prd = _repo.Add(products);
            if (prd == null)
            {
                return BadRequest("Product not create");
            }
            return Created("Product Added", prd);
        }
        [HttpGet]
        [Route("GetAll_Products")]

        public ActionResult<IEnumerable<Products>> GetAllProducts()
        {
            var prd = _repo.GetAll().ToList();
            if (prd.Count == 0)
                return NotFound("No Products present");
            return prd  ;
        }

        [HttpGet]
        [Route("GetProductsById/{id}")]
        public ActionResult<Products> GetEmployees(int id)
        {
            var prd = _repo.Get(id);
            if (prd == null)
                return NotFound("No employee with id " + id);
            return Ok(prd);
        }
        [HttpPut]
        [Route("Product_Update")]

        public ActionResult<Products> Update(int id, Products product)
        {
            var prd = _repo.Update(product);
            if (prd == null)
                return NotFound("No employee with id " + id);
            return Ok(product);
        }
        [HttpDelete]
        [Route("Product_Delete")]

        public ActionResult<Products> Delete(int id, Products product)
        {
            var prd = _repo.Delete(product);
            if (prd == null)
                return NotFound("No employee with id " + id);
            return Ok(product);
        }

        // Create
        [HttpPost]
        [Route("Product_AddingCart")]

        public ActionResult<Products> AddCart(Products cart)
        {
            var prd = _repo.AddCart(cart);
            if (prd == null)
            {
                return BadRequest("Product not create");
            }
            return Created("Product Added", prd);
        }

        [HttpGet]
        [Route("GetAll_Carts")]

        public ActionResult<IEnumerable<Products>> GetAllCarts()
        {
            var prd = _repo.GetAllCart().ToList();
            if (prd.Count == 0)
                return NotFound("No Products present");
            return prd;
        }

        [HttpDelete]
        [Route("Product_DeleteProductCart")]

        public ActionResult<Products> DeleteProductCart(Products product)
        {
            var prd = _repo.DeleteProductCart(product);
            if (prd == null)
                return NotFound("sry Some think is Rong ..!" );
            return Ok(product);
        }

        [HttpPut]
        [Route("Product_AddSameProductCart")]

        public ActionResult<Products> AddSameProduct(Products product)
        {
            var prd = _repo.AddSameProduct(product);
            if (prd == null)
                return NotFound("sry Some think is Rong ..!");
            return Ok(product);
        }

        [HttpPut]
        [Route("Product_DeleteSameProductCart")]

        public ActionResult<Products> DeleteSameProduct(Products product)
        {
            var prd = _repo.AddSameProduct(product);
            if (prd == null)
                return NotFound("sry Some think is Rong ..!");
            return Ok(product);
        }

    }
}
