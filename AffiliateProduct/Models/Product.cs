using System;
using System.Text.Json.Serialization;

namespace AffiliateProduct.Models;

public class Product
{
    public string? Name { get; set; }
    public string? Image { get; set; }
    public int Order { get; set; }
    [JsonPropertyName("shopee_url")]
    public string? ShopeeUrl { get; set; }
    [JsonPropertyName("tiktok_url")]
    public string? TiktokUrl { get; set; }
}
