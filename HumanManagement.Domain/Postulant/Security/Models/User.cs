
using HumanManagement.Domain.Security.Contracts;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using ICryptography = HumanManagement.Domain.Postulant.Security.Contracts.ICryptography;

namespace HumanManagement.Domain.Postulant.Models
{
     public class UserPostulant : BaseModel.BaseModel
    {
        [Column("nid_user")]
        public int Id { get; set; }

        [Column("susername")]
        public string UserName { get; set; }

        [Column("spassword")]
        public string Password { get; set; }

        [Column("nresetpassword")]
        public int? ResetPassword { get; set; }

        [Column("bchangedpassword")]
        public bool ChangedPassword { get; set; }
        [Column("bpasswordresetcode")]
        public byte[] PasswordResetCode { get; set; }
        [Column("dpasswordresetstart")]
        public DateTime? PasswordResetStart { get; set; }

        [Column("nstate")]
        public int State { get; set; }

        [Column("svalidationibformative")]
        public string ValidationInformative { get; set; }

        [Column("nid_person")]
        public int IdPerson { get; set; }

        [Column("sphoto_url")]
        public string PhotoUrl { get; set; }

        [Column("bblocked")]
        public bool? Blocked { get; set; }

        [Column("bactiveaccount")]
        public bool? ActiveAccount { get; set; }
        public UserPostulant()
        {
            Blocked = false;
        }

        public void SetEncryptPassword(ICryptography cryptography)
        {
            Password = cryptography.GetMd5Hash(Password);
        }

        public void SetEncryptPasswordRandom(ICryptography cryptography, string codePerson)
        {
            Password = cryptography.GetMd5Hash(codePerson);
        }

        public string GetPasswordRandom(IPasswordGenerator passwordGenerator)
        {
            return passwordGenerator.Generate(8);
        }
        public void UserRegistered()
        {
            
        }

    }
}
