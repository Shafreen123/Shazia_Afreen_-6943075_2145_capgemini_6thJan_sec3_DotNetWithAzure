namespace TransactionApp.API.DTOs;

// ONLY the fields the front-end is allowed to see.
// Notice: no Id, no UserId.
public record TransactionDto(
    decimal  Amount,
    DateTime Date,
    string   Type
);