using CRUD_API_IAN.DOMAIN.ENTITIES;
using CRUD_API_IAN.DTO;
using CRUD_API_IAN.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_API_IAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityMembersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommunityMembersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<List<CommunityMemberReadDto>> GetMembers()
        {
            var members = _unitOfWork.CommunityMembers.GetAllCommunityMembers()
                .Select(c => new CommunityMemberReadDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email,
                    Phone = c.Phone
                })
                .ToList();

            return Ok(members);
        }

        [HttpPost]
        public ActionResult CreateMember(CommunityMemberCreateDto memberDto)
        {
            var newMember = new CommunityMember
            {
                Name = memberDto.Name,
                Age = memberDto.Age,
                Email = memberDto.Email,
                Phone = memberDto.Phone
            };

            _unitOfWork.CommunityMembers.AddCommunityMember(newMember);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetMembers), new { id = newMember.Id }, memberDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMember(int id, CommunityMemberCreateDto memberDto)
        {
            var member = _unitOfWork.CommunityMembers.GetCommunityMemberById(id);
            if (member == null)
            {
                return NotFound("Miembro de la comunidad no encontrado.");
            }

            member.Name = memberDto.Name;
            member.Age = memberDto.Age;
            member.Email = memberDto.Email;
            member.Phone = memberDto.Phone;

            _unitOfWork.CommunityMembers.UpdateCommunityMember(member);
            _unitOfWork.Save(); 

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMember(int id)
        {
            var member = _unitOfWork.CommunityMembers.GetCommunityMemberById(id);
            if (member == null)
            {
                return NotFound("Miembro de la comunidad no encontrado.");
            }

            _unitOfWork.CommunityMembers.DeleteCommunityMember(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}