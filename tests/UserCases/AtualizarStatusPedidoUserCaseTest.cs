using Aplication;
using model;
using Model.UserCases;
using Moq;
using Repositories;

namespace Tests;

public class AtualizarStatusPedidoUserCaseTest
{

    [Fact]
    public void DadoUmNovoStatusParaOPedido_QuandoPedirParaAtualizar_DeveAlterarOStatusEADataDeAtualizacao()
    {
        // Given
        var pedido = new Pedido(1, Model.EStatusPedido.Recebido);

        var pedidoRepositorio = new Mock<IPedidoRepositorio>();
        pedidoRepositorio.Setup(x => x.ObterPedido(It.IsAny<int>())).Returns(pedido);
        pedidoRepositorio.Setup(x => x.AtualizarPedido(It.IsAny<Pedido>())).Returns(true);

        var usercase = new AtualizarStatusPedidoUserCase(pedidoRepositorio.Object);

        // When
        var sucess = usercase.Handle(1, Model.EStatusPedido.EmPreparacao);
    
        // Then
        Assert.True(sucess);
    }

    [Fact]
    public void DadoUmNovoStatusParaOPedido_QuandoPedidoIdForIgualAZero_DeveDarUmaExecption()
    {
        // Given
        var pedido = new Pedido(1, Model.EStatusPedido.Recebido);

        var pedidoRepositorio = new Mock<IPedidoRepositorio>();
        pedidoRepositorio.Setup(x => x.ObterPedido(It.IsAny<int>())).Returns(pedido);
        pedidoRepositorio.Setup(x => x.AtualizarPedido(It.IsAny<Pedido>())).Returns(true);

        var usercase = new AtualizarStatusPedidoUserCase(pedidoRepositorio.Object);

        // When 
        // Then
        var ex = Assert.Throws<ArgumentException>(() => usercase.Handle(0, Model.EStatusPedido.EmPreparacao));
    }
}
