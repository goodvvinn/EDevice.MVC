using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDevice.Entities;
using Microsoft.Extensions.Logging;

namespace EDevice.Providers
{
    public class DeviceProvider
    {
        private readonly ILogger<DeviceProvider> _logger;
        private readonly List<DeviceEntity> _entities = new List<DeviceEntity>();

        public DeviceProvider(ILogger<DeviceProvider> logger)
        {
            _logger = logger;
        }

        public async Task<DeviceEntity> GetByIdAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(GetByIdAsync)}");
            return await Task.Run(() =>
            {
                return _entities.FirstOrDefault(f => f.Id == id);
            });
        }

        public async Task<string> CreateAsync(string name, string title, string description, decimal price)
        {
            var id = Guid.NewGuid().ToString();
            _logger.LogInformation($"Started {nameof(CreateAsync)}");
            return await Task.Run(() =>
            {
                _entities.Add(new DeviceEntity()
                {
                    Id = id,
                    Description = description,
                    Title = title,
                    Price = price,
                });
                return id;
            });
        }

        public async Task<bool> UpdateAsync(string id, string title, string description, decimal price)
        {
            _logger.LogInformation($"Started {nameof(UpdateAsync)}");

            return await Task.Run(() =>
            {
                var item = _entities.FirstOrDefault(f => f.Id == id);
                if (item == null)
                {
                    return false;
                }

                item.Title = title;
                item.Description = description;
                item.Price = price;

                return true;
            });
        }

        public async Task<bool> DeleteAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(DeleteAsync)}");
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            return await Task.Run(() =>
            {
                var item = _entities.FirstOrDefault(f => f.Id == id);
                if (item == null)
                {
                    return false;
                }

                return _entities.Remove(item);
            });
        }
    }
}
