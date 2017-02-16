using System.Threading.Tasks;
using PgsBoard.Dtos;
using PgsBoard.ViewModels;

namespace PgsBoard.Services
{
    public interface IBoardsService
    {
        Task<MainPageViewModel> GetMainPageViewModel();
        Task CreateBoard(CreateBoardDto createBoardDto);
    }
}