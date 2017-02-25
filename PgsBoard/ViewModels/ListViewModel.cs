using System.Collections.Generic;
using PgsBoard.Dtos;

namespace PgsBoard.ViewModels
{
    public class ListViewModel
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public List<CartViewModel> Carts { get; set; }

        public CreateCartDto CreateCartDto { get; set; }

        public ListViewModel()
        {
            CreateCartDto = new CreateCartDto();
            Carts = new List<CartViewModel>();
        }
    }
}