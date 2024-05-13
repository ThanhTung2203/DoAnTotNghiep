using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepo;
        public InvoicesController(IInvoiceRepository invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInvoives()
        {
            await _invoiceRepo.GetAllInvoicesAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetInvoiceId(int id)
        {
            await _invoiceRepo.GetInvoiceByIdAsync(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult>AddInvoice(Invoice invoice)
        {
            var invoiceExist = await _invoiceRepo.InvoiceExist(invoice.Id);
            if(!invoiceExist)
            {
                return NotFound();
            }
            await _invoiceRepo.AddInvoiceAsync(invoice);
            return Ok("Thêm thành công!");
        }
        [HttpPut]
        public async Task<IActionResult>UpdateInvoice(int id,Invoice invoice)
        {
            try
            {
                var invoiceExist=await _invoiceRepo.InvoiceExist(id);
                if (!invoiceExist)
                {
                    return NotFound();
                }
                await _invoiceRepo.UpdateInvoiceAsync(id, invoice);
                return Ok("Cập nhật thành công!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteInvoice(int id)
        {
            try
            {
                await _invoiceRepo.DeleteInvoiceAsync(id);
                return Ok("Xóa thành công !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
