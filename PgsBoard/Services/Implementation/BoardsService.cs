using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using PgsBoard.Data.Entities;
using PgsBoard.Dtos;
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

            var userBoardsViewModel = userBoards.Select(x => new SelectListItem(){Value = x.Id.ToString(), Text = x.Name}).ToList();
            var mainBoardViewModel = new MainPageViewModel();
            mainBoardViewModel.UserBoards = userBoardsViewModel;

            return mainBoardViewModel;
        }

        public async Task CreateBoard(CreateBoardDto createBoardDto)
        {
            var currentUserId = _authInfrastructure.GetCurrentUserId();
            var board = new Board
            {
                Description = createBoardDto.Description,
                Name = createBoardDto.Name,
                OwnerId = currentUserId
            };
            _boardsRepository.Insert(board);
            await _boardsRepository.SaveChangesOnContext();
        }

        public async Task<ShowBoardViewModel> GetBoard(long selectedBoardId)
        {
            var board = await _boardsRepository.GetBoardWithListsAndCarts(selectedBoardId);
            if (board == null)
            {
                return null;
            }

            var showBoardViewModel = _mapper.Map<Board, ShowBoardViewModel>(board);
            return showBoardViewModel;
        }
    }
}