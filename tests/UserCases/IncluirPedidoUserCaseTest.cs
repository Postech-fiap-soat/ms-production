using Aplication;
using Model;
using Model.UserCases;
using Moq;
using Repositories;

namespace Tests;

public class IncluirPedidoUserCaseTest
{

    [Fact]
    public void DadoUmNovoPedido_QuandoIdForDiferenteDeZero_DeveCriarUmNovoPedido()
    {
        // Given
        var client = new Model.Client()
        {
            Identificacao = "CPF",
            NumeroIdentificacao = "99999999999",
            Email = "samle@sample.com",
            Nome = "nome",
            Sobrenome = "sample"
        };
        var pedido = new Pedido(1, Model.EStatusPedido.Recebido, client);

        var pedidoRepositorio = new Mock<IPedidoRepository>();
        pedidoRepositorio.Setup(x => x.IncluirPedido(It.IsAny<Pedido>())).Returns(pedido);

        var usercase = new IncluirPedidoUserCase(pedidoRepositorio.Object);

        // When
        var novoPedido = usercase.Handle(1, Model.EStatusPedido.Recebido, client);

        // Then
        Assert.Equal(1, novoPedido.Id);
        Assert.Equal(Model.EStatusPedido.Recebido, novoPedido.Status);
        Assert.Equal(DateTime.Now, novoPedido.DataAlteradoStatus, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void DadoUmNovoPedido_QuandoIdForIgualZero_DeveDarExcption()
    {
        // Given
        var pedidoRepositorio = new Mock<IPedidoRepository>();
        var usercase = new IncluirPedidoUserCase(pedidoRepositorio.Object);
        var client = new Model.Client()
        {
            Identificacao = "CPF",
            NumeroIdentificacao = "99999999999",
            Email = "samle@sample.com",
            Nome = "nome",
            Sobrenome = "sample"
        };

        // When
        // Then
        var ex = Assert.Throws<ArgumentException>(() => usercase.Handle(0, Model.EStatusPedido.Recebido, client));

    }
}
