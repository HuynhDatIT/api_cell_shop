namespace cell_shop_api.ViewModels.Response
{
    public class GetAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
