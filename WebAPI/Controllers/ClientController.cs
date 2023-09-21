using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Controllers;

public static class ClientController
{
    public static void MapClientEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/clients");

        group.MapGet("get_birthday_list/{date:datetime}", GetListOfBirthdayClients);
    }

    private static async Task<IResult> GetListOfBirthdayClients(DateTime date, AppDbContext db)
    {
        var clients = await db.Clients
            .Where(x => x.DateOfBirth.Month == date.Month && x.DateOfBirth.Day == date.Day)
            .ToListAsync();

        var clientsDto = clients.Select(x => new
        {
            x.Id,
            x.Initials
        });
        return Results.Ok(clientsDto);
    }


}