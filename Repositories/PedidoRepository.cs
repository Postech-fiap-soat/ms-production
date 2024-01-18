﻿using Model;
using MongoDB.Driver;

namespace Repositories;

public class PedidoRepository : IPedidoRepository
{
    public MongoDbConfiguration MongoDbConfiguration { get; }

    public PedidoRepository(MongoDbConfiguration mongoDbConfiguration)
    {
        MongoDbConfiguration = mongoDbConfiguration;
    }

    public Pedido ObterPedido(int pedidoId)
    {
        return MongoDbConfiguration.DB.GetCollection<Pedido>("Pedido").Find(p => p.Id == pedidoId).FirstOrDefault();
    }

    public bool AtualizarPedido(Pedido pedido)
    {
        return MongoDbConfiguration.DB.GetCollection<Pedido>("Pedido").ReplaceOne(p => p.Id == pedido.Id, pedido).IsAcknowledged;
    }

    public Pedido IncluirPedido(Pedido pedido)
    {
        MongoDbConfiguration.DB.GetCollection<Pedido>("Pedido").InsertOne(pedido);
        return pedido;
    }
}
