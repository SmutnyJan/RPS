using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPS.Model;

namespace RPS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Choice Player { get; set; }
        public Choice Computer { get; set; }
        [BindProperty]
        public int Round { get; set; }
        [BindProperty]
        public int Wins { get; set; }
        private Random _random;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _random = new Random();
        }

        public void OnGet()
        {
            Player = Choice.None;
            Computer = Choice.None;
            Round = 0;
            Wins = 0;
        }

        public void OnPost() {
            Computer = (Choice)_random.Next(1, 4);
            Round++;

            if(Player != Computer)
            {
                if ((Player == Choice.Rock && Computer == Choice.Scissors) || (Player == Choice.Scissors && Computer == Choice.Paper) || (Player == Choice.Paper && Computer == Choice.Rock)) {
                    Wins++;
                }
            }
        }
    }
}
