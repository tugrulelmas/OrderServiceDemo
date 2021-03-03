namespace OrderService.Services {
    public interface IEmailService {
        void SendEmail(int orderId, string content);
    }
}
