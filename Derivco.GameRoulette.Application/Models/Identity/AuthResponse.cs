namespace Derivco.GameRoulette.Application.Models.Identity
{
    /// <summary>
    /// E.g is the user above 18 years of age? 
    /// This auth class is to determine what resources a bettor/user is allowed to access
    /// </summary>
    public class AuthResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
