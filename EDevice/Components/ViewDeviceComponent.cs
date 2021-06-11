using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDevice.Controllers.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EDevice.Components
{
    public class ViewDeviceComponent : ViewComponent
    {
        private List<DeviceDTO> _devices;
        public ViewDeviceComponent()
        {
            _devices = new List<DeviceDTO>
            {
                new DeviceDTO
                {
                    Id = 1,
                    Category = "Operating Systems",
                    Title = "Windows XP",
                    Description = "Real long-life OS. It is actual even now",
                    Price = 300
                },
                new DeviceDTO
                {
                    Id = 2,
                    Category = "Laptops",
                    Title = "Sony VAIO SVP123A",
                    Description = "Lightweight carbon body with powerfull components for better performance",
                    Price = 15000
                },
                new DeviceDTO
                {
                    Id = 3,
                    Category = "Operating Systems",
                    Title = "Linux",
                    Description = "Ubuntu 20.01",
                    Price = 0
                },
                new DeviceDTO
                {
                    Id = 1,
                    Category = "Routers",
                    Title = "MicroTik",
                    Description = "For home and small office",
                    Price = 600
                },
                new DeviceDTO
                {
                    Id = 1,
                    Category = "Operating Systems",
                    Title = "Windows 10",
                    Description = "No Comments",
                    Price = 1500
                }
            };
        }

        public IViewComponentResult Invoke()
        {
            return View(_devices);
        }
    }
}
