using AutoMapper;
using TransactionApp.API.DTOs;
using TransactionApp.API.Models;

namespace TransactionApp.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Transaction entity → TransactionDto
        CreateMap<Transaction, TransactionDto>();
    }
}