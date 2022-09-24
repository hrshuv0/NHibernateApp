using FluentNHibernate.Mapping;
using InventoryApp.Models;

namespace InventoryApp.EntityMapper;

public class ProductMap : ClassMap<Product>
{
	public ProductMap()
	{
		Id(x => x.Id);

		Map(x => x.Name);
		Map(x => x.Category);

		Table("Product");
	}
}