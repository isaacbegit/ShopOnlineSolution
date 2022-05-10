using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductsBase:ComponentBase
    {
        [Inject]
        public IProductService productService { get; set; } 

        public IEnumerable<ProductDto> products { get; set; }
        protected override async Task OnInitializedAsync()
        {
            products = await productService.GetItems();
        }

    }
}
