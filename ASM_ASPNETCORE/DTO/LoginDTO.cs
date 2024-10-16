namespace ASM_ASPNETCORE.DTO
{
	public class LoginDTO
	{
        public string Email_Admin { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = false;
    }
}
