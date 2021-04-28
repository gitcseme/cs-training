using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using MovieData.Contexts;
using MovieData.Entities;
using MovieTracker.Extensions;

namespace MovieTracker.CachingHelpers
{
    public class RedisMovieCachingFilter : IAsyncResourceFilter
    {
        private readonly IDistributedCache _cache;
        private readonly MovieContext _dbContext;

        public RedisMovieCachingFilter(IDistributedCache cache, MovieContext dbContext)
        {
            _cache = cache;
            _dbContext = dbContext;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            // before
            var recordKey = "Redis_Caching_" + DateTime.Now.ToString("yyyyMMdd_hh");
            var movie = await _cache.GetRecordAsync<Movie>(recordKey);
            if (movie != null) {
                // return from here 
                context.Result = new OkObjectResult(movie);
                return;
            }

            var executedContext = await next();

            // after

            // Retrieve movie data from context and set to cache
            var response = executedContext.Result as ViewResult;
            movie = response.Model as Movie;
            await _cache.SetRecordAsync<Movie>(recordKey, movie);
        }
    }
}