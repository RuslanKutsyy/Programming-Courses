using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HospitalContext context = new HospitalContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
