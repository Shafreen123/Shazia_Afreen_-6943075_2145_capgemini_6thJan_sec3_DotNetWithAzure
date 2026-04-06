using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.Core.DTOs;
using SmartHealthcare.Core.Models;

namespace SmartHealthcare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BillsController : ControllerBase
    {
        private readonly IBillRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<BillsController> _logger;

        public BillsController(IBillRepository repo, IMapper mapper,
            ILogger<BillsController> logger)
        { _repo = repo; _mapper = mapper; _logger = logger; }

        // ── named-segment routes FIRST (before the generic {id:int}) ──────

        [HttpGet("appointment/{appointmentId:int}")]
        public async Task<IActionResult> GetByAppointment(int appointmentId)
        {
            var bill = await _repo.GetByAppointmentAsync(appointmentId);
            if (bill == null) return NotFound();
            return Ok(_mapper.Map<BillDto>(bill));
        }

        [HttpGet("patient/{patientId:int}")]           // ← THIS WAS MISSING
        public async Task<IActionResult> GetByPatient(int patientId)
        {
            var bills = await _repo.GetByPatientAsync(patientId);
            return Ok(_mapper.Map<IEnumerable<BillDto>>(bills)); // empty array, never 404
        }

        // ── generic routes after ───────────────────────────────────────────

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAll()
        {
            var bills = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BillDto>>(bills));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bill = await _repo.GetByIdAsync(id);
            if (bill == null) return NotFound();
            return Ok(_mapper.Map<BillDto>(bill));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> Create([FromBody] CreateBillDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var bill = _mapper.Map<Bill>(dto);
            var created = await _repo.CreateAsync(bill);
            _logger.LogInformation("Bill created for AppointmentId={Id}", dto.AppointmentId);
            return CreatedAtAction(nameof(GetById), new { id = created.Id },
                _mapper.Map<BillDto>(created));
        }

        [HttpPatch("{id:int}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateBillStatusDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _repo.UpdateStatusAsync(id, dto.Status);
            if (updated == null) return NotFound();
            return Ok(_mapper.Map<BillDto>(updated));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}