using WebAPI.Data.Models;

namespace WebAPI.Data.TestData;

public static class ClientTestData
{
    public static readonly List<Client> Clients = new()
    {
        new Client
        {
            Id = Guid.NewGuid(),
            Initials = "Client1",
            DateOfBirth = new DateTime(1990, 1, 1).ToUniversalTime(),
            DateOfRegistration = new DateTime(2020, 5, 10).ToUniversalTime(),
        },
        new Client
        {
            Id = Guid.NewGuid(),
            Initials = "Client2",
            DateOfBirth = new DateTime(1991, 2, 2).ToUniversalTime(),
            DateOfRegistration = new DateTime(2021, 6, 11).ToUniversalTime(),
        },
        new Client
        {
            Id = Guid.NewGuid(),
            Initials = "Client3",
            DateOfBirth = new DateTime(1985, 3, 15).ToUniversalTime(),
            DateOfRegistration = new DateTime(2019, 7, 20).ToUniversalTime(),
        },
        new Client
        {
            Id = Guid.NewGuid(),
            Initials = "Client4",
            DateOfBirth = new DateTime(1988, 4, 20).ToUniversalTime(),
            DateOfRegistration = new DateTime(2018, 8, 25).ToUniversalTime(),
        }
    };
}