using model;

namespace Tests;

public class PedidoTest
{

    [Fact]
    public void DadoUmPedidoRecebido_QuandoAtualizarStatus_DeveTerSeuStatusAtualizadoJuntoComDataAtualizacao()
    {
        // Given
        var pedido = new Pedido(10, Model.EStatusPedido.Recebido);

        // When
        pedido.AtualizarStatus(Model.EStatusPedido.EmPreparacao);

        // Then
        Assert.Equal(Model.EStatusPedido.EmPreparacao, pedido.Status);
        Assert.Equal(DateTime.Now, pedido.DataAlteradoStatus, TimeSpan.FromSeconds(1));
    }
    
}
