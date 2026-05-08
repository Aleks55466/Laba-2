using CommunityToolkit.Mvvm.ComponentModel;
using System;
using TodoApp.Desktop.ViewModels;

namespace TodoApp.Desktop.Services
{
    public class NavigationService : INavigationService
    {
        private readonly MainViewModel _mainViewModel;

        public NavigationService(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
        }

        public void NavigateTo(ObservableObject viewModel)
        {
            _mainViewModel.CurrentViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public void NavigateTo<TViewModel>() where TViewModel : ObservableObject, new()
        {
            _mainViewModel.CurrentViewModel = new TViewModel();
        }
    }
}