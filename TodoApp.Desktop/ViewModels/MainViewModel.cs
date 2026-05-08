using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TodoApp.Models;

namespace TodoApp.Desktop.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private object? _currentViewModel;
    private Profile? _currentProfile;

    public object? CurrentViewModel
    {
        get => _currentViewModel;
        set { _currentViewModel = value; OnPropertyChanged(); }
    }

    public Profile? CurrentProfile
    {
        get => _currentProfile;
        set { _currentProfile = value; OnPropertyChanged(); }
    }

    public MainViewModel() => CurrentViewModel = new LoginViewModel(this);

    public void OnLoginSuccess(Profile profile)
    {
        CurrentProfile = profile;
        CurrentViewModel = new TodoListViewModel(profile.Id, this);
    }

    // 🔴 Навигационные методы для TodoListViewModel
    public void NavigateToAddTask() => 
        CurrentViewModel = new AddTaskViewModel(CurrentProfile!.Id, this);
    
    public void NavigateToEditTask(TodoItem item) => 
        CurrentViewModel = new EditTaskViewModel(item, this);
    
    public void ReturnToTodoList()
    {
        if (CurrentProfile != null)
            CurrentViewModel = new TodoListViewModel(CurrentProfile.Id, this);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}