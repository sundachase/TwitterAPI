using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using DataAPI.Models;
using DataAPI.Extensions;

namespace DataAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TwitterController : ControllerBase
{
    private readonly ILogger<TwitterController> _logger;
    private const int PAGE_SIZE = 200;

    public TwitterController(ILogger<TwitterController> logger)
    {
        _logger = logger;
    }


    [HttpGet(Name = "GetTweets")]
    public IActionResult GetTweets([Required] int pageNum)
    {
        var tweets = new List<Tweet>();
        if (pageNum < 0)
        {
            _logger.LogWarning($"Page number cannot be negetive: {pageNum}");
        }
        else
        {
            int count = PAGE_SIZE;
            using (FileStream fs = System.IO.File.Open("./app_data/tweets.json", FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                sr.Skip(pageNum * PAGE_SIZE);
                //var watch = new System.Diagnostics.Stopwatch();
                //watch.Start();

                while (count-- > 0)
                {
                    var line = sr.ReadLine();

                    if (line != null)
                    {
                        Tweet? tweet = JsonSerializer.Deserialize<Tweet>(line);
                        if (tweet != null)
                            tweets.Add(tweet);
                    }
                    else
                    {
                        break;
                    }
                }

                //watch.Stop();
                //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            }
        }

        return Ok(tweets);
    }
}

