using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SalesContext context = new SalesContext();
            context.Database.EnsureCreated();
        }
    }
}