﻿using Visit.Domain.BL.DTO.Place;

namespace Visit.Domain.BL.Abstractions;

public interface IAttributeValueFactory
{
    Task<IEnumerable<AttributeValue>> CreateAttributeValues(IEnumerable<CreatePlaceAttributeValueDto> dtos);
}