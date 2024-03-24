using Aplication;
using Model;
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
          var client = new Model.Client() {
            Identificacao = "CPF",
            NumeroIdentificacao = "99999999999",
            Email = "samle@sample.com",
            Nome = "nome",
            Sobrenome = "sample"
        };
        var pedido = new Pedido(1, Model.EStatusPedido.Recebido, client);

        var pedidoRepositorio = new Mock<IPedidoRepository>();
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
          var client = new Model.Client() {
            Identificacao = "CPF",
            NumeroIdentificacao = "99999999999",
            Email = "samle@sample.com",
            Nome = "nome",
            Sobrenome = "sample"
        };
        var pedido = new Pedido(1, Model.EStatusPedido.Recebido, client);

        var pedidoRepositorio = new Mock<IPedidoRepository>();
        pedidoRepositorio.Setup(x => x.ObterPedido(It.IsAny<int>())).Returns(pedido);
        pedidoRepositorio.Setup(x => x.AtualizarPedido(It.IsAny<Pedido>())).Returns(true);

        var usercase = new AtualizarStatusPedidoUserCase(pedidoRepositorio.Object);

        // When 
        // Then
        var ex = Assert.Throws<ArgumentException>(() => usercase.Handle(0, Model.EStatusPedido.EmPreparacao));
    }
}
