using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceBackend.models.Users
{
    class ModelUsers
    {
        [Required(ErrorMessage = "Propriedade ID nao encontrada")]
        [MinLength(1)]
        public string Id { get; set; }

        public string Password { get; set; }

        [Required(ErrorMessage = "Propriedade UserId nao encontrada")]
        [Range(1, int.MaxValue, ErrorMessage = "Divergência encontrada e/ou não mapeada")]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Propriedade Name nao encontrada")]
        public string Name { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Propriedade NickName nao encontrada")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Propriedade Gender nao encontrada")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Propriedade LastName nao encontrada")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Propriedade LastName nao encontrada")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Propriedade DateOfBirth nao encontrada")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Propriedade CityId nao encontrada")]
        [Range(1, int.MaxValue, ErrorMessage = "Divergência encontrada e/ou não mapeada")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Propriedade StateId nao encontrada")]
        [Range(1, int.MaxValue, ErrorMessage = "Divergência encontrada e/ou não mapeada")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Propriedade Phone1 nao encontrada")]
        [MinLength(1)]
        public string Phone1 { get; set; }

        [Required(ErrorMessage = "Propriedade CpfNf nao encontrada")]
        public bool CpfNf { get; set; }

        public string Message { get; set; }

        public bool NLPActive { get; set; }

        public ModelCity City { get; set; }

        public ModelMember Member { get; set; }

        public ModelAppInfo AppInfo { get; set; }

        public object DeviceUUID { get; set; }
        public bool Confirmed { get; set; }
        public object BlockedUntil { get; set; }
        public int LoginFailedAttempts { get; set; }
        public int TermsOfUseAcceptedVersion { get; set; }
        public int PrivacyPolicyAcceptedVersion { get; set; }


    }
}
