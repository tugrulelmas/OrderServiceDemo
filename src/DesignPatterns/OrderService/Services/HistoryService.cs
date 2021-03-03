using System.Collections.Generic;

namespace OrderService.Services {
    public class HistoryService : IHistoryService {
        private readonly List<string> histories;

        public HistoryService() {
            histories = new List<string>();
        }

        public IEnumerable<string> GetAll() {
            return histories;
        }

        public void Push(string history) {
            histories.Add(history);
        }
    }
}
