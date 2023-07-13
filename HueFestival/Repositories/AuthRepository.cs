namespace HueFestival.Repositories
{
    using HueFestival.Data;

    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using HueFestival.Helper;
    using BC = BCrypt.Net.BCrypt;
    using HueFestival.Models;

    public class AuthRepository
    {
        private readonly HueFestivalContext context;
        private readonly IConfiguration configuration;

        public AuthRepository(HueFestivalContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public bool IsAuthenticated(string email, string password)
        {
            var user = this.GetByEmail(email);
            return this.DoesUserExists(email) && BC.Verify(password, user!.Password);
        }

        public bool DoesUserExists(string email)
        {
            var user = this.context.Users!.FirstOrDefault(x => x.Email == email);
            return user != null;
        }

        public User? GetById(string id)
        {
            return this.context.Users!.FirstOrDefault(c => c.UserId == id);
        }

        public User[] GetAll()
        {
            return this.context.Users!.ToArray();
        }

        public User? GetByEmail(string email)
        {
            return this.context.Users!.FirstOrDefault(c => c.Email == email);
        }
        public class IdGenerator
        {
            public static string CreateLetterId(int length)
            {
                var random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }
        public User RegisterUser(User model)
        {
            var id = IdGenerator.CreateLetterId(10);
            var existWithId = this.GetById(id);
            while (existWithId != null)
            {
                id = IdGenerator.CreateLetterId(10);
                existWithId = this.GetById(id);
            }
            model.UserId = id;
            model.Password = BC.HashPassword(model.Password);

            this.context.Users!.Add(model);
            this.context.SaveChanges();

            return model;
        }

        public string GenerateJwtToken(string email, string role)
        {
            var issuer = this.configuration["Jwt:Issuer"];
            var audience = this.configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(this.configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                            new Claim("Id", Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Sub, email),
                            new Claim(JwtRegisteredClaimNames.Email, email),
                            new Claim(ClaimTypes.Role, role),
                            new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                        }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string DecodeEmailFromToken(string token)
        {
            var decodedToken = new JwtSecurityTokenHandler();
            var indexOfTokenValue = 7;

            var t = decodedToken.ReadJwtToken(token.Substring(indexOfTokenValue));

            return t.Payload.FirstOrDefault(x => x.Key == "email").Value.ToString();
        }

        public User ChangeRole(string email, string role)
        {
            var user = this.GetByEmail(email);
            user!.Role = role;
            this.context.SaveChanges();


            return user;
        }
        



    }
}