using Model;

namespace Tests;

public class PedidoTest
{

    [Fact]
    public void DadoUmPedidoRecebido_QuandoAtualizarStatus_DeveTerSeuStatusAtualizadoJuntoComDataAtualizacao()
    {
        // Given
          var client = new Model.Client() {
            Identificacao = "CPF",
            NumeroIdentificacao = "99999999999",
            Email = "samle@sample.com",
            Nome = "nome",
            Sobrenome = "sample"
        };
        var pedido = new Pedido(10, Model.EStatusPedido.Recebido,client);

        // When
        pedido.AtualizarStatus(Model.EStatusPedido.EmPreparacao);

        // Then
        Assert.Equal(Model.EStatusPedido.EmPreparacao, pedido.Status);
        Assert.Equal(DateTime.Now, pedido.DataAlteradoStatus, TimeSpan.FromSeconds(1));
    }
    
}
