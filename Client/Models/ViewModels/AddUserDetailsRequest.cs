namespace Client.Models.ViewModels
{
    public class AddUserDetailsRequest
    {

        public int Id { get; set; }
        public long AccountNumber { get; set; }
        public string UserName { get; set; }
        public string UserNumber { get; set; }
        public DateTime UserDob { get; set; }

        public string District { get; set; }
        public string Municipality { get; set; }
        public string Tole { get; set; }
        public int? HouseNumber { get; set; }
        public int WardNumber { get; set; }
        public string? Education { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string? Spouse { get; set; }
        public string Occupation { get; set; }
        public string Institution { get; set; }
        public string Designation { get; set; }
        public string AnnualTransaction { get; set; }
        public bool OtherBank { get; set; }
        public bool CrimalAct { get; set; }
    }
}

