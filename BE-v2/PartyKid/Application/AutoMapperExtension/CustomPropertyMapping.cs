using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.OpenApi.Expressions;

namespace PartyKid;

public class CustomComboPropertyMapping : IValueResolver<UpdateComboBindingModel, Combo, string>
{

    public string Resolve(UpdateComboBindingModel source, Combo destination, string destMember, ResolutionContext context)
    {
        return !string.IsNullOrEmpty(source.Description) ? source.Description : destination.Description;
    }
}
