namespace OrderService.EventHandlers {
    public interface IEventHandler<in T> {
        void Handle(T eventInstance);
    }
}
