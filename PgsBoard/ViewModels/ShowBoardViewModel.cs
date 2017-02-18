using System.Collections.Generic;
using PgsBoard.Dtos;

namespace PgsBoard.ViewModels
{
    public class ShowBoardViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string OwnerName { get; set; }

        public List<ListViewModel> Lists { get; set; }

        public CreateListDto CreateListDto { get; set; }

        public ShowBoardViewModel()
        {
            CreateListDto = new CreateListDto();
            Lists = new List<ListViewModel>();
        }
    }
}