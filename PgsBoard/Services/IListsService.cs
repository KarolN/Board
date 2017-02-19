using System.Threading.Tasks;
using PgsBoard.Dtos;

namespace PgsBoard.Services
{
    public interface IListsService
    {
        Task<long?> CreateNewList(CreateListDto createListDto);
    }
}