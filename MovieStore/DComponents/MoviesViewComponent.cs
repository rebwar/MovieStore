﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.DComponents
{
    public class MoviesViewComponent:ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
