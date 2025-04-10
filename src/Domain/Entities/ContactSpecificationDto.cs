﻿using Domain.DataTypes;

namespace Domain.Entities;

public class ContactSpecificationDto : BaseEntityWithIdDto
{
    
}

public sealed class ContactSpecificationDtoPersonalName : ContactSpecificationDto
{
    public required string PersonalName { get; init; }
}
public sealed class ContactSpecificationDtoOrganisationName : ContactSpecificationDto
{
    public required string OrganisationName { get; init; }
}
public sealed class ContactSpecificationDtoPhoneNumber : ContactSpecificationDto
{
    public required PhoneNumber PhoneNumber { get; init; }
}

public sealed class ContactSpecificationDtoMailAddress : ContactSpecificationDto
{
    public required MailAddress MailAddress { get; init; }
}

public sealed class ContactSpecificationDtoPostalAddress : ContactSpecificationDto
{
    public required PostalAddress PostalAddress { get; init; }
}
public sealed class ContactSpecificationDtoBankAccount : ContactSpecificationDto
{
  public required BankAccount BankAccount { get; init; }
}
public sealed class ContactSpecificationDtoWebsite : ContactSpecificationDto
{
  public required Url Website { get; init; }
}
public sealed class ContactSpecificationDtoPaypal : ContactSpecificationDto
{
  public required MailAddress PaypalAddress { get; init; }
  public required Url PaypalMeAddress { get; init; }
}
