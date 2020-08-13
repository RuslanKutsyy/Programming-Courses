namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var moviesDto = JsonConvert.DeserializeObject<List<ImportMovieDto>>(jsonString);
            List<Movie> movies = new List<Movie>();

            foreach (var movieDto in moviesDto)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGenreValid = Enum.TryParse(typeof(Genre), movieDto.Genre, out object genre);

                if (!isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var existingMovie = movies.FirstOrDefault(x => x.Title == movieDto.Title);

                if (existingMovie != null)
                {
                    sb.AppendLine(ErrorMessage);
                }

                var movie = Mapper.Map<Movie>(movieDto);

                movies.Add(movie);
                sb.AppendLine(String.Format(SuccessfulImportMovie, movieDto.Title, movieDto.Genre, movieDto.Rating.ToString("F2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var moviesDto = JsonConvert.DeserializeObject<List<ImportHallSeatDto>>(jsonString);
            List<Hall> halls = new List<Hall>();

            foreach (var hallDto in halls)
            {
                if (IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D
                };

                foreach (var seat in hallDto.Seats)
                {
                    hall.Seats.Add(new Seat());
                }

                string hallType = "";

                if (hall.Is4Dx)
                {
                    hallType = hall.Is3D ? "4Dx/3D" : "4Dx";
                }
                else if (hall.Is3D)
                {
                    hallType = "3D";
                }
                else
                {
                    hallType = "Normal";
                }

                halls.Add(hall);

                sb.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, hallType, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}