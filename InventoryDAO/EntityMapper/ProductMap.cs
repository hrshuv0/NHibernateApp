using Entities;
using FluentNHibernate.Mapping;

namespace InventoryDAO.EntityMapper;

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