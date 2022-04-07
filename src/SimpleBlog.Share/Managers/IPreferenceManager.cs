using SimpleBlog.Share.Settings;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Share.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}