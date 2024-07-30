using System;

namespace JdMarketplace.Core.Dominio.Entities.CustomerAggregate.Events;

public class CustomerDeletedEvent(
    Guid id,
    string firstName,
    string lastName,
    EGender gender,
    string email,
    DateTime dateOfBirth) : CustomerBaseEvent(id, firstName, lastName, gender, email, dateOfBirth)
{
}