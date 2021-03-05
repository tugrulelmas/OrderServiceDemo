using System.Collections.Generic;

namespace Order.HistoryService.Services {
    public interface IHistoryService {
        void Push(string history);

        IEnumerable<string> GetAll();
        void DeleteAll();
    }
}
