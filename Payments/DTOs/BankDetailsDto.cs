using System.ComponentModel.DataAnnotations;

namespace Marketplacesellerportal.Payments.DTOs
{
    public class BankDetailsDto
    {
        public string? BankName { get; set; }

        public string? AccountHolderName { get; set; }

        public string? AccountNumber { get; set; }

        public string? IFSCCode { get; set; }

        public string? BranchName { get; set; }
    }
}
