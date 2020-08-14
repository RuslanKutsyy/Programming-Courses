namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var departmentsCellsDto = JsonConvert.DeserializeObject<List<ImportDepartmentsCellsDto>>(jsonString);
            List<Department> departments = new List<Department>();

            foreach (var departmentDto in departmentsCellsDto)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentDto.Name,
                };
                
                bool isDepartmentValid = true;

                foreach (var cellDto in departmentDto.Cells)
                {
                    Cell cell = new Cell();

                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine("Invalid Data");
                        isDepartmentValid = false;
                        break;
                    }

                    if (isDepartmentValid)
                    {
                        department.Cells.Add(cell);
                    }
                }

                if (isDepartmentValid)
                {
                    departments.Add(department);
                    sb.AppendLine(String.Format($"Imported {departmentDto.Name} with {department.Cells.Count} cells"));
                }
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var prisonersMailDtos = JsonConvert.DeserializeObject<List<ImportPrisonersMailsDto>>(jsonString);
            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersMailDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                string nickname;

                if (String.IsNullOrEmpty(prisonerDto.Nickname))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else
                {
                    if (!prisonerDto.Nickname.StartsWith("The "))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    nickname = prisonerDto.Nickname;
                }

                DateTime IncarcerationDate;

                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out IncarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? ReleaseDate;

                if (!String.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    DateTime prisonerReleaseDate;
                    bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out prisonerReleaseDate);
                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    ReleaseDate = prisonerReleaseDate;
                }
                else
                {
                    ReleaseDate = null;
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.Fullname,
                    Nickname = nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = IncarcerationDate,
                    ReleaseDate = ReleaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                };

                bool isPrisonerValid = true;

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine("Invalid Data");
                        isPrisonerValid = false;
                        break;
                    }

                    string address;

                    if (!mailDto.Address.EndsWith("str."))
                    {
                        sb.AppendLine("Invalid Data");
                        isPrisonerValid = false;
                        break;
                    }

                    address = mailDto.Address;

                    var mail = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = address,
                        PrisonerId = prisoner.Id
                    };

                    prisoner.Mails.Add(mail);
                }

                if (isPrisonerValid)
                {
                    prisoners.Add(prisoner);
                    sb.AppendLine($"Imported {prisonerDto.Fullname} {prisonerDto.Age} years old");
                }
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportOfficersPrisonersDto>), new XmlRootAttribute("Officers"));
            var officersDtos = (List<ImportOfficersPrisonersDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var officers = new List<Officer>();

            foreach (var officerDto in officersDtos)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                decimal salary;

                if (officerDto.Money < 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                salary = officerDto.Money;

                bool isPositionValid = Enum.TryParse(typeof(Position), officerDto.Position, out object position);

                if (!isPositionValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                bool isOfficerValid = Enum.TryParse(typeof(Weapon), officerDto.weapon, out object weapon);

                if (!isOfficerValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = salary,
                    Position = (Position)position,
                    Weapon = (Weapon)weapon,
                    DepartmentId = officerDto.DepartmentId
                };

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    var officerPrisoner = new OfficerPrisoner
                    {
                        OfficerId = officer.Id,
                        PrisonerId = prisonerDto.Id
                    };
                    officer.OfficerPrisoners.Add(officerPrisoner);
                }

                officers.Add(officer);
                sb.AppendLine($"Imported {officerDto.Name} ({officer.OfficerPrisoners.Count} prisoners)");
            }
            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}