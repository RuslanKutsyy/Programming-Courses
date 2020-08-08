namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var gamesDtos = JsonConvert.DeserializeObject<List<ImportGameDto>>(jsonString);
			List<Game> games = new List<Game>();

            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }
				//check game Price
				decimal gamePrice;

                if (!(gameDto.Price >= 0))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}
				gamePrice = gameDto.Price;

				//check game Release Date
				DateTime gameReleaseDate;

				bool isGameReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out gameReleaseDate);

                if (!isGameReleaseDateValid)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}


				//check and create developer
				var dev = context.Developers.FirstOrDefault(x => x.Name == gameDto.Developer);

                if (dev == null)
                {
					dev = new Developer
					{
						Name = gameDto.Developer
					};

					context.Developers.Add(dev);
                }

				//check and create genre
				var gameGenre = context.Genres.FirstOrDefault(x => x.Name == gameDto.Genre);

                if (gameGenre == null)
                {
					gameGenre = new Genre
					{
						Name = gameDto.Genre
					};
					context.Genres.Add(gameGenre);
                }

				var game = new Game
				{
					Name = gameDto.Name,
					Price = gamePrice,
					DeveloperId = dev.Id,
					GenreId = gameGenre.Id
				};

				//check all and create tags

				List<string> gameTags = new List<string>();

                foreach (var tagText in gameDto.Tags)
                {
					var gameTag = context.Tags.FirstOrDefault(x => x.Name == tagText);

					if (gameTag == null)
					{
						gameTag = new Tag
						{
							Name = tagText,
						};
						context.Tags.Add(gameTag);
					}

					game.GameTags.Add(new GameTag
					{
						Game = game,
						Tag = gameTag
					});

					gameTags.Add(tagText);
				}

				games.Add(game);
				sb.AppendLine($"Added {gameDto.Name} ({gameDto.Genre}) with {gameTags.Count} tags");
			}

			context.Games.AddRange(games);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var usersDtos = JsonConvert.DeserializeObject<List<ImportUserDto>>(jsonString);
			List<User> users = new List<User>();
			//bool isUserValid = true;

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }
				var user = new User
				{
					FullName = userDto.FullName,
					Username = userDto.Username,
					Email = userDto.Email,
					Age = userDto.Age
				};

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
						sb.AppendLine("Invalid Data");
						continue;
					}

					var cardEnumValues = Enum.GetNames(typeof(CardType));

                    if (!cardEnumValues.Any(x => x == cardDto.Type))
                    {
						sb.AppendLine("Invalid Data");
						continue;
					}
					var card = new Card
					{
						Number = cardDto.Number,
						Cvc = cardDto.CVC,
						Type = (CardType)Enum.Parse(typeof(CardType), cardDto.Type),
						User = user
					};
					user.Cards.Add(card);
                }

				users.Add(user);
				sb.AppendLine($"Imported {userDto.Username} with {user.Cards.Count} cards");
            }
			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportPurchaseDto>), new XmlRootAttribute("Purchases"));
			var purchasesDtos = (List<ImportPurchaseDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

			var purchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesDtos)
            {
				if (!IsValid(purchaseDto))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				var purchaseEnumValues = Enum.GetNames(typeof(PurchaseType));

				if (!purchaseEnumValues.Any(x => x == purchaseDto.Type))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				DateTime date;

				bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out date);

                if (!isDateValid)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

                if (card == null)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var purchase = new Purchase
				{
					Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseDto.Type),
					ProductKey = purchaseDto.Key,
					CardId = card.Id,
					Date = date
				};
				var username = context.Cards.FirstOrDefault(x => x.Id == card.Id).User.Username;
				purchases.Add(purchase);
				sb.AppendLine($"Imported {purchaseDto.Title} for {username}");
			}

			context.Purchases.AddRange(purchases);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}