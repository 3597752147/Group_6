using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BusinessObject;
using DataAccess.Repository;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
        }
        [Route("api/[controller]")]


        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetMembers()
        {
            var members = _memberRepository.GetMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public ActionResult<Member> GetMember(int id)
        {
            var member = _memberRepository.GetMemberById(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        [HttpPost]
        public ActionResult<Member> CreateMember(Member member)
        {
            _memberRepository.AddMember(member);
            return CreatedAtAction(nameof(GetMember), new { id = member.MemberId }, member);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, Member member)
        {
            if (id != member.MemberId) return BadRequest();
            if (_memberRepository.GetMemberById(id) == null) return NotFound();

            _memberRepository.UpdateMember(member);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var member = _memberRepository.GetMemberById(id);
            if (member == null) return NotFound();

            _memberRepository.DeleteMember(id);
            return NoContent();
        }
    }
}
