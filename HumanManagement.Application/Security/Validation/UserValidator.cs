using FluentValidation;
using HumanManagement.Domain.Security.Dto;

namespace HumanManagement.Application.Security.Validation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(d => d.FirstName).NotEmpty()
                .WithMessage("El Primer Nombre es un dato obligatorio");
            RuleFor(d => d.SecondName).NotEmpty()
                .WithMessage("El Segundo Nombre es un dato obligatorio");
            RuleFor(d => d.LastName).NotEmpty()
                .WithMessage("El Apellido Paterno es un dato obligatorio");
            RuleFor(d => d.MotherLastName).NotEmpty()
                .WithMessage("El Apellido Materno es un dato obligatorio");
            RuleFor(d => d.Email).NotEmpty()
                .WithMessage("El Correo es un dato obligatorio");
            RuleFor(d => d.UserName).NotEmpty()
                .WithMessage("El Nombre de Usuario es un dato obligatorio");

            RuleFor(d => d.PasswordWithoutEncryption).NotEmpty()
                .When(x => x.Id == 0)
                .WithMessage("La Contraseña es un dato obligatorio");

            RuleFor(d => d.PasswordConfirm).NotEmpty()
                .When(x => x.Id == 0)
                .WithMessage("La Confirmación de la Contraseña es un dato obligatorio");

            RuleFor(d => d.PasswordWithoutEncryption).Equal(d=>d.PasswordConfirm)
                .When(x => x.Id == 0)
                .WithMessage("Las Contraseñas no coinciden");
        }
    }
}
