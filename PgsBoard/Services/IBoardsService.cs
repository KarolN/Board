using System.Threading.Tasks;
using PgsBoard.ViewModels;

namespace PgsBoard.Services
{
    public interface IBoardsService
    {
        Task<MainPageViewModel> GetMainPageViewModel();
    }
}