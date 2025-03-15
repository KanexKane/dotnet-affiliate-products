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
    protected override async Task OnInitializedAsync()
    {
        products = await HttpClient.GetFromJsonAsync<List<Product>>("data/product.json") ?? new List<Product>();
    }
}
