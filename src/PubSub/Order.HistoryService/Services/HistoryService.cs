using System.Collections.Generic;

namespace Order.HistoryService.Services {
    public class HistoryService : IHistoryService {
        private readonly List<string> histories;

        public HistoryService() {
            histories = new List<string>();
        }

        public void DeleteAll() {
            histories.Clear();
        }

        public IEnumerable<string> GetAll() {
            return histories;
        }

        public void Push(string history) {
            histories.Add(history);
        }
    }
}
