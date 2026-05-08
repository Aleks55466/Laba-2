using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace TodoApp.Desktop.Services
{
    public interface INavigationService
    {
        void NavigateTo(ObservableObject viewModel);

        void NavigateTo<TViewModel>() where TViewModel : ObservableObject, new();
    }
}