using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TransactionApp.API.Data;
using TransactionApp.API.DTOs;

namespace TransactionApp.API.Controllers;

[Route("api/transactions")]
[ApiController]
[Authorize]                         // ← JWT required for ALL endpoints here
public class TransactionsController(
    AppDbContext db,
    IMapper     mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetMyTransactions()
    {
        // ── Business Rule: extract userId from JWT claims ──
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim is null) return Unauthorized();

        var userId = int.Parse(userIdClaim);

        // ── Business Rule: ONLY return this user's rows ──
        var transactions = await db.Transactions
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.Date)
            .ToListAsync();

        // ── AutoMapper: entity → DTO (hides Id and UserId) ──
        var dtos = mapper.Map<List<TransactionDto>>(transactions);
        return Ok(dtos);
    }
}