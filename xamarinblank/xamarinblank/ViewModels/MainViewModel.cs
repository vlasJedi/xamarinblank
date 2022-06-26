using xamarinblank.Repositories;

namespace xamarinblank.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly TodoItemRepository _repository;

        public MainViewModel(TodoItemRepository repository)
        {
            _repository = repository;
            LoadData();
        }

        private void LoadData()
        {
            
        }
    }
}