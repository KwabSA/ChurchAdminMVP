using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ChurchAdminMVP.Data;
using ChurchAdminMVP.Models;

namespace ChurchAdminMVP.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly AppDbContext _context;

    public MembersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/members — Admin sees all, member sees own
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var members = await _context.Members
            .Where(m => m.UserId == userId)
            .ToListAsync();
        return Ok(members);
    }

    // GET: api/members/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Member>> GetMember(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var member = await _context.Members
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);
        if (member == null) return NotFound();
        return Ok(member);
    }

    // POST: api/members — Create own profile
    [HttpPost]
    public async Task<ActionResult<Member>> CreateMember(Member member)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        member.UserId = userId!;
        _context.Members.Add(member);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMember), new { id = member.Id }, member);
    }

    // PUT: api/members/1 — Update own profile
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMember(int id, Member member)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var existing = await _context.Members
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);
        if (existing == null) return NotFound();

        existing.FirstName = member.FirstName;
        existing.LastName = member.LastName;
        existing.PhoneNumber = member.PhoneNumber;
        existing.DateOfBirth = member.DateOfBirth;
        existing.Gender = member.Gender;
        existing.Address = member.Address;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}