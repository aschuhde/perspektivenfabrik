using Domain.Entities;
using Infrastructure.Data.DbEntities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Data.Mapping;


public static partial class MappingExtensions
{
    // From DB
    public static partial OtpDto ToOtpDto(this DbOtp dbOtp);
    
    // To DB
    public static partial DbOtp ToDbOtp(this OtpDto otpDto);
}
