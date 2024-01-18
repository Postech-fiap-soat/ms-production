using Aplication;
using Model;
using Model.UserCases;
using Moq;
using Repositories;

namespace Tests;

public class ObterPedidoUserCaseTest
{

    [Fact]
    public void DadoUmPedidoId_QuandoIdForDiferenteDeZero_DeveBuscarOPedido()
    {
        // Given
        var pedido = new Pedido(1, Model.EStatusPedido.Recebido);

        var pedidoRepositorio = new Mock<IPedidoRepository>();
        pedidoRepositorio.Setup(x => x.ObterPedido(It.IsAny<int>())).Returns(pedido);

        var usercase = new ObterPedidoUserCase(pedidoRepositorio.Object);

        // When
        var novoPedido = usercase.Handle(1);
    
        // Then
        Assert.NotNull(novoPedido);
    }

    [Fact]
    public void DadoUmPedidoId_QuandoIdForIgualZero_DeveDarExcption()
    {
        // Given
        var pedidoRepositorio = new Mock<IPedidoRepository>();
        var usercase = new ObterPedidoUserCase(pedidoRepositorio.Object);

        // When
        // Then
        var ex = Assert.Throws<ArgumentException>(() => usercase.Handle(0));

    }
}
