#nullable enable
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace Wpf.Infrastructure;

public abstract class ViewModelBase : IViewModel
{
    protected Dispatcher CurrentDispatcher = Application.Current.Dispatcher;

    public event PropertyChangedEventHandler? PropertyChanged = delegate { };

    protected virtual void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual void RaisePropertyChangedInCurrentDispatcher(string propertyName)
    {
        CurrentDispatcher.Invoke(() => RaisePropertyChanged(propertyName));
    }

    protected virtual void RaiseCommandCanExecuteChanged(ICommandWithRaiseCanExecute command)
    {
        command.RaiseCanExecuteChanged();
    }

    protected virtual void RaiseCommandCanExecuteChangedInCurrentDispathcer(ICommandWithRaiseCanExecute command)
    {
        CurrentDispatcher.Invoke(() => RaiseCommandCanExecuteChanged(command));
    }

    protected T RaiseAndSetIfChanged<T>(ref T field, T newValue, [CallerMemberName] string? propertyName = null)
    {
        ArgumentNullException.ThrowIfNull(propertyName, nameof(propertyName));

        if (EqualityComparer<T>.Default.Equals(field, newValue))
        {
            return newValue;
        }

        field = newValue;
        RaisePropertyChanged(propertyName);
        return newValue;
    }
}
