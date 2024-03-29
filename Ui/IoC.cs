using System.Diagnostics.CodeAnalysis;
using Aplication;
using Model;
using Model.UserCases;
using RabbitMq;
using Repositories;

namespace Ui;

[ExcludeFromCodeCoverage]
public static class Ioc
{
    public static void AddIoc(this IServiceCollection serviceCollection){
        serviceCollection.AddSingleton<IPedidoRepository, PedidoRepository>();

        serviceCollection.AddSingleton<IAtualizarStatusPedidoUserCase, AtualizarStatusPedidoUserCase>();
        serviceCollection.AddSingleton<IListarPedidoPorStatusUserCase, ListarPedidoPorStatusUserCase>();
        serviceCollection.AddSingleton<IIncluirPedidoUserCase, IncluirPedidoUserCase>();
        serviceCollection.AddSingleton<IObterPedidoUserCase, ObterPedidoUserCase>();

        serviceCollection.AddSingleton<MongoDbConfiguration>();
    }
}
