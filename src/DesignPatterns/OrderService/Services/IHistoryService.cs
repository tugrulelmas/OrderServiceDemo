using System.Collections.Generic;

namespace OrderService.Services {
    public interface IHistoryService {
        void Push(string history);

        IEnumerable<string> GetAll();
    }
}
