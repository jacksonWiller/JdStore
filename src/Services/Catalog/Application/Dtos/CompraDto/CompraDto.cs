using System.Collections.Generic;

namespace AplicationApp.Dtos
{
    public class CompraDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<ItemPedidoDto> ItensDeCompra { get; set; }
    }
}