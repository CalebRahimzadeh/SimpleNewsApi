namespace SimpleNews.Domain.Models.Auth
{
    // TODO: Determine if all auth models and dependencies can be split out into a seperate project when there is enough of a reason. - CR 05/09/2023
    // This is a dumb quick implementation.
    // Static due to it not being instance based.
    public class ApiKey
    {
        public ApiKey(string key)
        {
            Key = key;
        }
        public string Key { get; private set; }
    }
}
