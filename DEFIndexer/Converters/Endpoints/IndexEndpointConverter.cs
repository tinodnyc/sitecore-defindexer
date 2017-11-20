using System;
using DEFIndexer.ItemModels;
using DEFIndexer.Plugins;
using Sitecore.Configuration;
using Sitecore.DataExchange.Converters.Endpoints;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace DEFIndexer.Converters.Endpoints
{
    public class IndexEndpointConverter : BaseEndpointConverter
    {
        public IndexEndpointConverter(IItemModelRepository repository) : base(repository)
        {
            var templateId = Guid.Parse(Settings.GetSetting("DEF.IndexEndpointConverter.Id"));
            this.SupportedTemplateIds.Add(templateId);
        }

        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            //create the plugin
            var settings = new IndexSettings();
            settings.IndexName = base.GetStringValue(source, IndexSettingsItemModel.IndexName);
            endpoint.Plugins.Add(settings);
        }
    }
}
