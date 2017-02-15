using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PgsBoard.Data.Entities;
using PgsBoard.Infrastructure;
using PgsBoard.Repositories;
using PgsBoard.ViewModels;

namespace PgsBoard.Services.Implementation
{
    public class BoardsService : IBoardsService
    {
        private readonly IMapper _mapper;
        private readonly IBoardsRepository _boardsRepository;
        private readonly IAuthInfrastructure _authInfrastructure;

        public BoardsService(IMapper mapper, IBoardsRepository boardsRepository,
                                IAuthInfrastructure authInfrastructure)
        {
            _mapper = mapper;
            _boardsRepository = boardsRepository;
            _authInfrastructure = authInfrastructure;
        }

        public async Task<MainPageViewModel> GetMainPageViewModel()
        {
            var currentUserId = _authInfrastructure.GetCurrentUserId();
            var userBoards = await _boardsRepository.GetUserBoards(currentUserId);

            var userBoardsViewModel = _mapper.Map<List<Board>, List<UserBoardsSelectionViewModel>>(userBoards);
            var mainBoardViewModel = new MainPageViewModel();
            mainBoardViewModel.UserBoards = userBoardsViewModel;

            return mainBoardViewModel;
        }
    }
}