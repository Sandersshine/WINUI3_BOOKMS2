using Microsoft.UI.Xaml;

using WINUI3_BOOKMS2.Contracts.Services;
using WINUI3_BOOKMS2.ViewModels;

namespace WINUI3_BOOKMS2.Activation;

public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly INavigationService _navigationService;

    public DefaultActivationHandler(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
    {
        // None of the ActivationHandlers has handled the activation.
        return _navigationService.Frame?.Content == null;
    }

    protected async override Task HandleInternalAsync(LaunchActivatedEventArgs args)
    {
        _navigationService.NavigateTo(typeof(BookListViewModel).FullName!, args.Arguments);

        await Task.CompletedTask;
    }
}
