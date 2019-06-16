using BLRI.Entity.Auth;
using BLRI.ViewModel.Auth;

namespace BLRI.Manager.Map
{
    public static class ModelUpdater
    {
        public static void UpdateUserModel(this User user, UserViewModel viewModel)
        {
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Email = viewModel.Email;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.UserName = viewModel.UserName;
        }
    }
}
