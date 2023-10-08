﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BTL_NguyenVanTruong_.Models;
using BTL_NguyenVanTruong_.DAL;
using Microsoft.Extensions.Configuration;
using BTL_NguyenVanTruong_.BLL;
using BTL_NguyenVanTruong_.BLL.Interfaces;
namespace BTL_NguyenVanTruong_.API_User.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IProductBusiness _prb;
        public ProductController(IProductBusiness prb)
        {
            _prb = prb;
        }
        [HttpGet("getlistsp")]
        public ActionResult<List<ProductsModel>> GetProductById()
        {
            try
            {
                var productList = _prb.GetListProduct();

                if (productList == null || productList.Count == 0)
                {
                    return NotFound("Danh sách sản phẩm trống");
                }

                return Ok(productList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult<ProductsModel> GetProductById(int id)
        {
            var product = _prb.GetProductByMaSP(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("create-product")]
        public ActionResult CreateProduct([FromBody] ProductsModel model)
        {
            var result = _prb.CreateProduct(model);
            return Ok(result);
        }

        [HttpPut("update-product")]
        public ActionResult UpdateProduct([FromBody] ProductsModel model)
        {
            var result = _prb.UpdateProduct(model);
            return Ok(result);
        }

        [HttpDelete("delete-product/{masp}")]
        public ActionResult DeleteProduct(int masp)
        {
            var result = _prb.DeleteProduct(masp);
            return Ok(result);
        }
    }
}
