using Aplication;
using Model.UserCases;
using Repositories;

namespace Ui;

public static class Ioc
{
    public static void AddIoc(this IServiceCollection serviceCollection){
        serviceCollection.AddScoped<IPedidoRepository, PedidoRepository>();
        serviceCollection.AddScoped<IAtualizarStatusPedidoUserCase, AtualizarStatusPedidoUserCase>();
        serviceCollection.AddScoped<IIncluirPedidoUserCase, IncluirPedidoUserCase>();
        serviceCollection.AddScoped<IObterPedidoUserCase, ObterPedidoUserCase>();

        serviceCollection.AddSingleton<MongoDbConfiguration>();
    }
}
