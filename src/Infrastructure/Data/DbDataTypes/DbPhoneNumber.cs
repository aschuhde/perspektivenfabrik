﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbPhoneNumber
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string PhoneNumberText { get; init; }
}