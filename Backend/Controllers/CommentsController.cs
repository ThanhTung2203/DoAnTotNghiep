using AutoMapper;
using Backend.Dto;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsRepository _commentsRepo;
        private readonly IMapper _mapper;
        public CommentsController(IMapper mapper,ICommentsRepository commentRepo)
        {
            _commentsRepo = commentRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Comment>> GetComments( )
        {
            return await _commentsRepo.GetComments();
            

        }
        [HttpGet("{id}")]
        public async Task<Comment> GetComment(int id)
        {
            return await _commentsRepo.GetComment(id);
        }
        [HttpPost]
        public async Task<IActionResult> PostComment(CommentDto commentDto)
        {
            try
            {
                var comment=_mapper.Map<Comment>(commentDto);
                await _commentsRepo.PostComment(comment);
                return Ok("thanh cong");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public async Task UpdateComment(Comment comment)
        {
            try
            {
                await _commentsRepo.UpdateComment(comment);
            }
            catch(Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task DeleteComment(int id)
        {
            try
            {
                await _commentsRepo.DeleteComment(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
    }
}
