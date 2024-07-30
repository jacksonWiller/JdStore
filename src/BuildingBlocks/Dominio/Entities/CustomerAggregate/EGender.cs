using System.ComponentModel;

namespace JdMarketplace.Core.Dominio.Entities.CustomerAggregate;

public enum EGender
{
    [Description("Não informar")]
    None = 0,

    [Description("Masculino")]
    Male = 1,

    [Description("Feminino")]
    Female = 2
}