﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieHallAPI.Abstraction;
using MovieHallAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHallAPI.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        ILogger _logger;
        IMovieHallProcessor _movieHallProcessor;
        public MoviesController(IMovieHallProcessor processor, ILogger<MoviesController> logger)
        {
            _logger = logger;
            _movieHallProcessor = processor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return StatusCode(200, "test");
        }

        [HttpPost]
        public IActionResult GetAllmovies()
        {
           
            MovieHallAPIResponse response = _movieHallProcessor.GetAllMovies();
            return StatusCode(200,response);
        }

        [HttpGet]
        public IActionResult FindMovie(string name)
        {
            Movie response = _movieHallProcessor.FindMovieByName(name);
            return StatusCode(200, response);
        }
    }
}
