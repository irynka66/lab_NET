using Microsoft.EntityFrameworkCore;
using Travels.Models;

namespace Travels.Services;

public record SummaryRow(string Name, int Count, decimal Total);

public static class SummaryCalculator
{
    public static async Task<List<SummaryRow>> ByCountryAsync(IQueryable<Trip> query) =>
        await query
            .GroupBy(x => x.Country!.Name)
            .OrderByDescending(g => g.Sum(x => x.TotalCost))
            .Select(g => new SummaryRow(g.Key, g.Count(), g.Sum(x => x.TotalCost)))
            .ToListAsync();

    public static async Task<List<SummaryRow>> ByMonthAsync(IQueryable<Trip> query)
    {
        var raw = await query
            .GroupBy(x => new { x.StartDate.Year, x.StartDate.Month })
            .Select(g => new
            {
                g.Key.Year,
                g.Key.Month,
                Count = g.Count(),
                Total = g.Sum(x => x.TotalCost)
            })
            .ToListAsync();

        return raw
            .OrderBy(r => r.Year).ThenBy(r => r.Month)
            .Select(r => new SummaryRow($"{r.Month:D2}.{r.Year}", r.Count, r.Total))
            .ToList();
    }

    public static async Task<SummaryRow> TotalAsync(IQueryable<Trip> query) =>
        new SummaryRow(
            "Усього",
            await query.CountAsync(),
            await query.SumAsync(x => x.TotalCost));
}