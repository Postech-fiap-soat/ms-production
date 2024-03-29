﻿using Model;
using Model.UserCases;
using Repositories;

namespace Aplication;

public class IncluirPedidoUserCase : IIncluirPedidoUserCase
{
    private readonly IPedidoRepository pedidoRepositorio;
    public IncluirPedidoUserCase(IPedidoRepository pedidoRepositorio)
    {
        this.pedidoRepositorio = pedidoRepositorio;
    }


    public Pedido Handle(int pedidoId, EStatusPedido statusPedido, Client client)
    {
        if(pedidoId == 0)
            throw new ArgumentException("pedidoId não pode ser 0");

        var pedido = new Pedido(pedidoId, statusPedido, client);

        return this.pedidoRepositorio.IncluirPedido(pedido);
    }
}
