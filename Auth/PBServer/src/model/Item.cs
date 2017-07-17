using PBServer.src.templates;
using System;

namespace PBServer.src.model
{
	public abstract class Item
	{
		private ItemTemplate _template;

		public Item(ItemTemplate template)
		{
			this._template = template;
		}

		public ItemTemplate getTemplate()
		{
			return this._template;
		}
	}
}
