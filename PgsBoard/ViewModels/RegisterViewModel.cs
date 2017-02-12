using PgsBoard.Dtos;

namespace PgsBoard.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterUserDto RegisterUserDto { get; set; }

        public RegisterViewModel()
        {
            RegisterUserDto = new RegisterUserDto();
        }
    }
}