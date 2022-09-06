using System;
using static DataAPI.Controllers.TwitterController;

namespace DataAPI.Models
{
	public class Tweet
	{
        public string? content { get; set; }
        
        public Twitter? user { get; set; }
    }

    public class Twitter
    {
        public string? username { get; set; }
        public int followersCount { get; set; }
        public int friendsCount { get; set; }
    }
}

