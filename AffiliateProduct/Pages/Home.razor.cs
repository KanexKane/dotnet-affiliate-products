using System;
using System.Net.Http.Json;
using AffiliateProduct.Models;
using Microsoft.AspNetCore.Components;

namespace AffiliateProduct.Pages;

public partial class Home
{
    [Inject]
    public HttpClient HttpClient { get; set; } = default!;

    List<Product> products = new List<Product>();

    private string selectedOrderBy = "name"; // ค่าเริ่มต้น

    protected override async Task OnInitializedAsync()
    {
        products = await HttpClient.GetFromJsonAsync<List<Product>>("data/product.json") ?? new List<Product>();

        SortProducts();

    }

    private void OnSortChanged(ChangeEventArgs e)
    {
        selectedOrderBy = e.Value?.ToString() ?? "name"; // อัปเดตค่าที่เลือก
        SortProducts(); // เรียงลำดับใหม่
    }

    private void SortProducts()
    {

        if (selectedOrderBy == "order")
        {
            products = products.OrderBy(p => p.Order).ToList();
        }
        else if (selectedOrderBy == "name")
        {
            products = products.OrderBy(p => p.Name).ToList();
        }

        StateHasChanged();
    }
}
