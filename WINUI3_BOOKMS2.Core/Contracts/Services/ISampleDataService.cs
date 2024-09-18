using WINUI3_BOOKMS2.Core.Models;

namespace WINUI3_BOOKMS2.Core.Contracts.Services;

// Remove this class once your pages/features are using your data.
public interface ISampleDataService
{
    Task<IEnumerable<SampleOrder>> GetGridDataAsync();
}
