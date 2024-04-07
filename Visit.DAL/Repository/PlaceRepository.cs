using System.Text;
using Microsoft.EntityFrameworkCore;
using Visit.DAL.Helpers;
using Visit.Domain;
using Visit.Domain.BL.Abstractions.Repository;
using Visit.Domain.BL.DTO.Place;

namespace Visit.DAL.Repository;

public class PlaceRepository(DataContext dataContext) : IPlaceRepository
{
    public async Task<Place> Create(Place place)
    {
        dataContext.Categories.AttachRange(place.Categories);
        dataContext.Places.Add(place);

        await dataContext.SaveChangesAsync();

        return await GetById(place.Id);
    }

    public async Task<Place> GetById(int id)
    {
        return await dataContext.Places
            .Include(p => p.Categories)
            .Include(p => p.AttributeValues)
            .ThenInclude(p => p.Attribute)
            .AsSplitQuery()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Place>> GetByFilter(SearchPlaceFilterDto filter)
    {
        var attributes = await dataContext.Attributes
            .Where(a => filter.AttributeValues.Select(dto => dto.AttributeId).Contains(a.Id))
            .ToDictionaryAsync(a => a.Id, a => a);

        // черная магия с dynamic sql
        var sql = new StringBuilder("""select p.* from "Places" p""" + "\n");
        var whereSqlFilter = new List<string>();

        for (int i = 0; i < filter.AttributeValues.Length; i++)
        {
            var atrValue = filter.AttributeValues[i];
            var a = attributes[atrValue.AttributeId];
            var values = atrValue.Values;
            var value = atrValue.Value;

            var av = $"av{i}";
            var join = $"""join "AttributeValues" {av} on p."Id" = {av}."PlaceId" """;

            var where = new StringBuilder($"""({av}."AttributeId" = {a.Id} and """);
            switch (a.Type)
            {
                case AttributeType.String when a.AllowMultipleValues:
                    where.Append($"""{av}."StringValue" in {values.ToDbString(a.Type)})""");
                    break;
                case AttributeType.String when !a.AllowMultipleValues:
                    where.Append($"""{av}."StringValue" = {value.ToDbString(a.Type)})""");
                    break;
                case AttributeType.Int when a.AllowMultipleValues:
                    where.Append($"""{av}."IntValue" in {values.ToDbString(a.Type)})""");
                    break;
                case AttributeType.Int when !a.AllowMultipleValues:
                    where.Append($"""{av}."IntValue" = {value.ToDbString(a.Type)})""");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            whereSqlFilter.Add(where.ToString());
            sql.AppendLine(join);
        }

        sql.AppendLine("where");
        sql.AppendLine(string.Join(" and ", whereSqlFilter));
        sql.AppendLine($"limit {filter.Count} offset {filter.Offset}");

        return await dataContext.Places.FromSqlRaw(sql.ToString()).ToListAsync();
    }

    public async Task Delete(int id)
    {
        await dataContext.Places.Where(p => p.Id == id).ExecuteDeleteAsync();
    }
}