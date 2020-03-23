﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotnetcoreProject.Core.Models;
using DotnetcoreProject.Core.Service;
using DotnetcoreProject.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DotnetcoreProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category)); 
        }
    }
}