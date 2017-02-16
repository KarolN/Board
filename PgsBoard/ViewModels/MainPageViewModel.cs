using System.Collections.Generic;
using System.Web.Mvc;
using PgsBoard.Dtos;

namespace PgsBoard.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<SelectListItem> UserBoards { get; set; }
        public CreateBoardDto CreateBoardDto { get; set; }

        public MainPageViewModel()
        {
            CreateBoardDto = new CreateBoardDto();
        }
    }
}