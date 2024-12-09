/*[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost]
    public async Task<IActionResult> PurchaseTicket(PurchaseTicketDto ticketDto)
    {
        var ticket = await _ticketService.PurchaseTicketAsync(ticketDto);
        return Ok(ticket);
    }
}*/
