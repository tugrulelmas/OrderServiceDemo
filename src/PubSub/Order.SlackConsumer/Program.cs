using Microsoft.Extensions.DependencyInjection;
using Order.Core;

namespace Order.SlackConsumer {
    class Program {
        static void Main(string[] args) {
            using (var services = RegisterServices()) {
                services.UseAutoSubscriber();
                while (true) { }
            }
        }

        private static ServiceProvider RegisterServices() {
            return new ServiceCollection()
                .AddPubSub()
                .BuildServiceProvider();
        }
    }
}
